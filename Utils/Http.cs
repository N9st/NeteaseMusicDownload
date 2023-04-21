using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Diagnostics;
using Sunny.UI;
using System.Linq;
using System.IO;

namespace NeteaseMusicDownloadWinForm.Utility
{
    class Http
    {
        private static readonly HttpClientHandler HttpClientHandler = new HttpClientHandler()
        {
            //不自动使用cookie
            UseCookies = false,
            //同一时间最大连接数
            MaxConnectionsPerServer = 5,
            
        };
        private static readonly HttpClient HttpClient = new HttpClient(HttpClientHandler);
        private static HttpResponseMessage httpResponseMessage;
        //post通用方法，根据T的类型返回不同的内容
        public static async Task<T> Post<T>(string url, Dictionary<string, string> postDatas)
        {
            //T的类型是啥子呢？
            Type tType = typeof(T);
            //设置请求头
            SetRequestHeaders();
            try
            {
                //post提交数据，数据需url编码
                httpResponseMessage = await HttpClient.PostAsync(url, new FormUrlEncodedContent(postDatas));
                //判断T的类型符合哪种
                if (tType.Equals(typeof(byte[])))
                {
                    //返回string类型的内容
                    return (T)(object)await httpResponseMessage.Content.ReadAsByteArrayAsync();
                }
                if (tType.Equals(typeof(JsonNode)))
                {
                    //以string类型读取网页内容
                    string respResult = await httpResponseMessage.Content.ReadAsStringAsync();
                    //打印看看输出什么
                    Trace.WriteLine(respResult);
                    //返回以JsonNode类型读取网页内容
                    return (T)(object)JsonNode.Parse(respResult);
                    //jsonNode的default是null
                }
                //啥也不是返回他自己的默认值
                return default;
            }
            catch (Exception) 
            {
                //抓到异常直接返回default
                return default;
            }
        }
        //get通用方法，根据T的类型返回不同的内容
        public static async Task<T> Get<T>(string url)
        {
            //T的类型是啥子呢？
            Type tType = typeof(T);
            //设置请求头
            SetRequestHeaders();
            try
            {
                httpResponseMessage = await HttpClient.GetAsync(url);
                //这网易云还玩小心思，搞个utf8，HttpClient识别不了
                //这里估计有点小问题，httpResponseMessage有可能是null，就会报错NullReferenceException
                httpResponseMessage.Content.Headers.ContentType.CharSet = "utf-8";
                if (tType.Equals(typeof(Stream)))
                {
                    return (T)(object)await httpResponseMessage.Content.ReadAsStreamAsync();
                }
                if (tType.Equals(typeof(string)))
                {
                    return (T)(object)await httpResponseMessage.Content.ReadAsStringAsync();
                }
                //啥也不是返回他自己的默认值
                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }
        //获取响应的cookie
        public static string GetRespnseCookie()
        {
            //尝试取Set-Cookie的值
            if (!httpResponseMessage.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> cookieResult))
            {
                return null;
            }
            string MUSIC_U = cookieResult.Where(x => x.Contains("MUSIC_U")).First().ToString().Substring(8,160);
            string __csrf = cookieResult.Where(x => x.Contains("__csrf")).First().ToString().Substring(7, 32);
            return $"{{\n  \"MUSIC_U\": \"{MUSIC_U}\",\n  \"__csrf\": \"{__csrf}\"\n}}";
        }
        //设置请求头
        private static void SetRequestHeaders()
        {
            HttpClient.DefaultRequestHeaders.Clear();
            //请求头
            string UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 Edg/112.0.1722.39";
            //添加请求头
            HttpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            HttpClient.DefaultRequestHeaders.Add("Cookie", Login.Cookie);
        }
        //析构函数，释放HttpClient，会不会执行俺也不知道
        ~Http()
        {
            HttpClient.Dispose();
        }
    }
}
