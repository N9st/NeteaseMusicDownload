using System;
using System.Text.Json.Nodes;

namespace NeteaseMusicDownloadWinForm.Utils
{
    class N9stJson
    {
        public static JsonNode Parse(string content)
        {
            JsonNode jsonNode;
            try
            {
                jsonNode = JsonNode.Parse(content);
            }
            catch (Exception)
            {
                return null;
            }
            return jsonNode;
        }
    }
}
