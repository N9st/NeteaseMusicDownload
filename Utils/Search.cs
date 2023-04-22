using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json.Nodes;

namespace NeteaseMusicDownloadWinForm.Utils
{
    class Search
    {
        //按照表格的顺序保存歌曲的Id
        public static readonly List<string> SongIdList = new List<string>();
        //通过网易云获取音乐信息
        public static async Task<JsonNode> GetSongs(string searchWord)
        {
            //搜索的url
            string searchUrl = @"https://music.163.com/weapi/cloudsearch/get/web";
            //需要加密的数据，limit:30，默认返回30首歌曲
            string needEncryptContent = "{\"hlpretag\":\"<span class=\\\"s-fc7\\\">\",\"hlposttag\":\"</span>\",\"id\":\"3778678\",\"s\":\"" +
                       $"{searchWord}" +
                       "\",\"type\":\"1\",\"offset\":\"0\",\"total\":\"true\",\"limit\":\"30\",\"csrf_token\":\"\"}";
            //第二次Aes-CBC加密需要用的key
            string aesSecondKey = Crypto.ReturnAesSecondKey();
            //即将要提交的数据
            Dictionary<string, string> postDatas = new Dictionary<string, string>()
            {
                ["params"] = Crypto.ReturnWeapiParams(needEncryptContent, aesSecondKey),
                ["encSecKey"] = Crypto.ReturnWeapiEncSecKey(aesSecondKey)
            };
            //返回网页的string内容
            JsonNode jsonNode = await Http.Post<JsonNode>(searchUrl, postDatas);
            return jsonNode;
        }
    }
}
