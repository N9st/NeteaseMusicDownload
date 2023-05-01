using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace NeteaseMusicDownloadWinForm.Utils
{
    class Crypto
    {
        //Aes加密和解密的key（ECB模式）
        private static readonly string EapiKey = "e82ckenh8dichen8";
        //获取参数Weapi-Params
        public static string ReturnWeapiParams(string needEncryptContent, string aesSecondKey)
        {
            //第一个Aes加密的key是固定不变的，第二个key才是动态的
            string aesFirstKey = "0CoJUm6Qyw8W8jud";
            string encryptFirstResult = Convert.ToBase64String(AesEncrypt(needEncryptContent, aesFirstKey, "CBC"));
            string encryptSecondResult = Convert.ToBase64String(AesEncrypt(encryptFirstResult, aesSecondKey, "CBC"));
            //返回string的结果
            return encryptSecondResult;
        }
        //获取aesSecondKey，这个方法完全模仿网易云的js写，当然有非常简单的方式可以实现一样的效果
        public static string ReturnAesSecondKey()
        {
            string aesSecondKey = string.Empty;
            Random rnd = new Random();
            string b = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for (int j = 0; 16 > j; j++)
            {
                //rnd.NextDouble()获取double的0-1之间的数，不包括1
                double e = rnd.NextDouble() * b.Length;
                //Floor舍去小数点后的所有数
                e = Math.Floor(e);
                //字符串拼接
                aesSecondKey += b[(int)e];
            }
            return aesSecondKey;
        }
        //获取参数Weapi-EncSecKey（Rsa无padding加密）
        public static string ReturnWeapiEncSecKey(string aesSecondKey)
        {
            //十六进制的exponent和modulus
            string exponent = "010001";
            string modulus = "00e0b509f6259df8642dbc35662901477df22677ec152b5ff68a" +
                "ce615bb7b725152b3ab17a876aea8a5aa76d2e417629ec4ee341f56135fccf695" +
                "280104e0312ecbda92557c93870114af6c9d05c4f7f0c3685b7a46bee25593257" +
                "5cce10b424d813cfe4875d3e82047b97ddef52741d546b8e289dc6935b3ece046" +
                "2db0a22b8e7";
            //字符串password翻转
            string password = new string(aesSecondKey.Reverse().ToArray());
            //将字符串转换为十六进制
            password = BitConverter.ToString(Encoding.UTF8.GetBytes(password)).Replace("-", "");
            //将十六进制转换为十进制
            BigInteger bigExponent = BigInteger.Parse(exponent, NumberStyles.HexNumber);
            BigInteger bigModulus = BigInteger.Parse(modulus, NumberStyles.HexNumber);
            BigInteger bigPassword = BigInteger.Parse(password, NumberStyles.HexNumber);
            //bigPassword的bigModulus次方 % bigExponent  （求模）
            string encSecKey = BigInteger.ModPow(bigPassword, bigExponent, bigModulus).ToString("x");
            //ToString("x")十六进制字母开头的会自己在前面加个“0”，所以跳过
            return new string(encSecKey.SkipWhile(x => x == '0').Take(256).ToArray());
        }
        //获取参数Eapi-Params
        public static string ReturnEapiParams(string songId)
        {
            Random random = new Random();
            //随机八位数
            char[] chars = "0123456789".ToCharArray();
            string uuid = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                uuid += chars[random.Next(0, 10)];
            }
            //歌曲信息（核心）
            string text = "{ \"id\": \"" +
                $"{songId}" +
                "\", \"level\": \"hires\", \"effects\": \"[null]\", \"e_r\": true, \"" +
                "header\": \"{\\\"os\\\":\\\"pc\\\",\\\"appver\\\":\\\"2.10.8.200945\\\",\\\"" +
                "deviceId\\\":\\\"E621AA1F0A45438E6EB7A2D87210C4A830A915846C24081320C4\\\",\\\"" +
                "requestId\\\":\\\"" +
                $"{uuid}" +
                "\\\",\\\"" +
                "clientSign\\\":\\\"BC:6E:E2:39:CF:42@@@303041305F373530315F333439315F364888666E" +
                "@@@@@@d6905186-4fb5-43d5-8a6a-511476f2f80f901160524193889aa45d8d4835666888\\\",\\\"" +
                "osver\\\":\\\"Microsoft-Windows-10-Home-China-build-22621-64bit\\\",\\\"" +
                "Nm-GCore-Status\\\":\\\"1\\\"}\" }";
            //需提交的数据（未加密）
            string message = "nobody" + "/api/song/enhance/download/url/v1" + "use" + 
                text + "md5forencrypt";
            string data = "/api/song/enhance/download/url/v1" + "-36cd479b6b5-" +
                $"{text}" + "-36cd479b6b5-" +
                $"{MD5Encrypt(message)}";
            //先Aes-ECB加密，然后返回十六进制的字符串，把“-”删了
            return BitConverter.ToString(AesEncrypt(data, EapiKey, "ecb")).Replace("-", "");
        }
        //封装AES-ECB解密方法
        public static string AesDecrypt(byte[] byteContent)
        {
            byte[] byteKey = Encoding.UTF8.GetBytes(EapiKey);
            //创建对象
            var aes = Aes.Create();
            //AES加密模式，可以修改，如ECB，默认为CBC
            aes.Mode = CipherMode.ECB;
            //赋值Key
            aes.Key = byteKey;
            //创建解密对象
            ICryptoTransform cryptor = aes.CreateDecryptor();
            //开始转换，依次是需解密的内容、偏移量、内容的长度
            byte[] byteDecrypted;
            try
            {
                byteDecrypted = cryptor.TransformFinalBlock(byteContent, 0, byteContent.Length);
            }
            catch(Exception)
            {
                return null;
            }
            finally
            {
                //释放资源
                cryptor.Dispose();
            }
            //返回UTF8编码后的字符串
            return Encoding.UTF8.GetString(byteDecrypted);
        }
        //小写32位的md5加密
        private static string MD5Encrypt(string password)
        {
            string pwd = string.Empty;
            byte[] temp = Encoding.UTF8.GetBytes(password);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(temp);
            for (int i = 0; i < result.Length; i++)
            {
                //大写MD5（X2）或者小写MD5（x2）
                pwd += result[i].ToString("x2");
            }
            return pwd;
        }
        //封装AES-CBC、ECB加密方法
        private static byte[] AesEncrypt(string content, string key, string mode)
        {
            //传入string content、string aesKey可以食用以下语句
            byte[] byteContent = Encoding.UTF8.GetBytes(content);
            byte[] byteKey = Encoding.UTF8.GetBytes(key);
            //创建AES对象
            var aes = Aes.Create();
            if (mode == "CBC")
            {
                //AES加密模式，可以修改，如ECB，默认为CBC
                aes.Mode = CipherMode.CBC;
                byte[] byteIV = Encoding.UTF8.GetBytes("0102030405060708");
                //赋值IV
                aes.IV = byteIV;
                //填充模式，可以修改，如PKCS7，默认为PKCS7
                aes.Padding = PaddingMode.PKCS7;
            }
            else
            {
                //AES加密模式，可以修改，如ECB，默认为CBC
                aes.Mode = CipherMode.ECB;
            }
            //赋值Key
            aes.Key = byteKey;
            //创建加密对象
            ICryptoTransform crypto = aes.CreateEncryptor();
            //开始转换，依次是需加密的内容、偏移量、内容的长度
            byte[] byteEncrypted = crypto.TransformFinalBlock(byteContent, 0, byteContent.Length);
            //释放资源
            crypto.Dispose();
            //返回base64编码后的结果
            return byteEncrypted;
        }
    }
}
