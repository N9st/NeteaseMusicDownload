using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;
using System.Text.Json.Nodes;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace NeteaseMusicDownloadWinForm.Utils
{
    class Login
    {
        //生成二维码需要用的key，检测二维码状态也需要用到的
        private static string UniKey = null;
        //Cookie保存位置
        public static readonly string ConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NeteaseCookie.json";
        //用于储存登录之后的cookie
        public static string Cookie = null;
        //静态构造函数，自动获取保存在本地的Cookie，全局只会自动执行一次
        static Login()
        {
            ReadCookie();
        }
        //获取生成二维码需要用的key
        public static async Task<string> GetLoginKey()
        {
            //post访问的url
            string url = "https://music.163.com/weapi/login/qrcode/unikey";
            //需要加密的内容
            string needEncryptContent = "{\"type\":1,\"noCheckToken\":true}";
            //十六位随机字符串
            string aesSecondKey = Crypto.ReturnAesSecondKey();
            //即将要提交的数据
            Dictionary<string, string> postDatas = new Dictionary<string, string>()
            {
                ["params"] = Crypto.ReturnWeapiParams(needEncryptContent, aesSecondKey),
                ["encSecKey"] = Crypto.ReturnWeapiEncSecKey(aesSecondKey)
            };
            //post提交数据并以jsonNode类型获取网页内容
            JsonNode jsonNode = await Http.Post<JsonNode>(url, postDatas);
            //网易云有时候返回null，我也不知道为啥
            UniKey = jsonNode?["unikey"]?.ToString();
            return UniKey;
        }
        //检查二维码的状态，是否过期、是否被扫描、是否授权中，处于授权中顺便获取用户名
        public static async Task<string> CheckQrCodeStatus()
        {
            //post访问的url
            string url = "https://music.163.com/weapi/login/qrcode/client/login";
            //需要被加密的内容
            string needEncryptContent = "{\"type\":1,\"noCheckToken\":true,\"key\":\"" +
                $"{UniKey}" +
                "\"}";
            //获取十六位随机字符串
            string aesSecondKey = Crypto.ReturnAesSecondKey();
            //即将要提交的数据
            Dictionary<string, string> postDatas = new Dictionary<string, string>()
            {
                ["params"] = Crypto.ReturnWeapiParams(needEncryptContent, aesSecondKey),
                ["encSecKey"] = Crypto.ReturnWeapiEncSecKey(aesSecondKey)
            };
            //post提交数据并以jsonNode类型获取网页内容
            JsonNode jsonNode = await Http.Post<JsonNode>(url, postDatas);
            //网易云有时候返回null，我也不知道为啥
            return jsonNode?["message"]?.ToString();
        }
        //生成网易云登录的二维码
        public static Bitmap GenerateQrCode(string content, int width, int height)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE
            };
            QrCodeEncodingOptions qrEncodingOptions = new QrCodeEncodingOptions()
            {
                DisableECI = true,
                CharacterSet = "UTF-8",//编码类型
                Width = width,//宽度
                Height = height,//高度
                Margin = 1  //设置二维码的边缘距离
            };
            barcodeWriter.Options = qrEncodingOptions;
            Bitmap bitmap = barcodeWriter.Write(content);
            return bitmap;
        }
        //保存登录之后的cookie，避免多次登录导致账号异常
        public static void SaveLoginCookie()
        {
            string loginCookie = Http.GetRespnseCookie();
            File.WriteAllText(ConfigPath, loginCookie);
        }
        //获取登录之后的用户名
        public static async Task<string> ReturnUserName()
        {
            //存在访问失败的可能，解决办法，重新打开软件重新登录咯
            string respResult = await Http.Get<string>(@"https://music.163.com") ?? "";
            //子表达式
            Match match = Regex.Match(respResult, @"nickname:""(?<nickname>(.*?))""");
            if (match.Success)
            {
                return $"欢迎登录，{match.Groups["nickname"].Value}，如遇下载失败，请多试几次";
            }
            else
            {
                return "尚未登录，请点击登录";
            }
        }
        //读取本地的cookie
        public static void ReadCookie()
        {
            //文件不存在，就直接return
            if (!File.Exists(Login.ConfigPath))
            {
                return;
            }
            //解析json数据
            try
            {
                JsonNode jsonNode = JsonNode.Parse(File.ReadAllText(Login.ConfigPath));
                Cookie = "os=pc; " +
                    "__remember_me=true; " +
                    $"MUSIC_U={jsonNode["MUSIC_U"]}; " +
                    $"__csrf={jsonNode["__csrf"]}; " +
                    "appver=2.10.8.200945; ";
            }
            //解析出错还是Cookie还是null
            catch (Exception)
            {
                Cookie = null;
            }
        }
    }
}
