using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace NeteaseMusicDownloadWinForm.Utils
{
    class Download
    {
        //歌曲的保存路径
        public static readonly string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        //获取下载链接
        public static async Task<string> GetLink(string songId)
        {
            //即将post访问的url
            string url = "https://interface.music.163.com/eapi/song/enhance/download/url/v1";
            //提交提交的数据
            Dictionary<string, string> postDatas = new Dictionary<string, string>()
            {
                {"params", Crypto.ReturnEapiParams(songId)},
            };
            //返回byte[]类型的内容
            byte[] respResult = await Http.Post<byte[]>(url, postDatas);
            //有可能网易云返回空，也有可能jsonNode["data"]["url"].ToString()为空
            JsonNode jsonNode = N9stJson.Parse(Crypto.AesDecrypt(respResult));
            Trace.WriteLine(jsonNode);
            return jsonNode["data"]["url"]?.ToString();
        }
        //下载音乐
        public static async Task Save(string downloadUrl, string fileName, IProgress<double> process)
        {
            //以stream方式网页内容
            Stream stream = await Http.Get<Stream>(downloadUrl);
            if (stream == null) 
            {
                process.Report(-0.01);
                return;  
            }
            //文件大小
            long fileSize = stream.Length ;
            //新建filename文件
            FileStream output = new FileStream(fileName, FileMode.CreateNew);
            //得到一个1024*1024字节数组
            byte[] buffer = new byte[1024 * 1024];
            //用于储存实际读到的大小
            int bytesRead;
            //下载进度
            double progress = 0.00;
            //循环读取，位置从0开始读，buffer.Length为实际读取长度，提供一个数组buffer用于储存数据
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                //写入buffer数组的数据，从位置0开始写，bytesRead为读取的实际大小
                output.Write(buffer, 0, bytesRead);
                //每次写入都增加进度，两个整数型相除会自动取整，所以要*1.0，这里是大坑
                progress = (bytesRead * 1.0 / fileSize) + progress;
                //下这么快干嘛？做点节目效果吧
                Thread.Sleep(100);
                //报告进度
                process.Report(progress);
            }
            //清除缓冲区，并将所有缓冲的数据写入文件。
            output.Flush();
            //关闭文件流
            output.Close();
            //释放文件流
            output.Dispose();
        }
    }
}
