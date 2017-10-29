using clby_ufop.Core.Misc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace clby_ufop.Core
{
    public static class HandlerHelper
    {

        public static async Task<byte[]> GetFileContentsAsync(this Controller controller)
        {
            var url = controller.GetStringParameter("url");

            byte[] fileContents;
            if (!string.IsNullOrEmpty(url))
            {
                using (var handler = new HttpClientHandler())
                using (var c = new HttpClient(handler))
                {
                    fileContents = await c.GetByteArrayAsync(url);
                }
            }
            else
            {
                using (var br = new BinaryReader(controller.Request.Body))
                {
                    fileContents = br.ReadAllBytes();
                }
            }

            return fileContents;

        }

        public static HandlerArgs GetArgs(this Controller controller)
        {
            var url = controller.GetStringParameter("url", "");
            var cmd = controller.GetStringParameter("cmd", "");

            var arr = cmd.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (arr == null || !arr.Any() || arr.Length < 2)
            {
                throw new ArgumentException($"参数错误:{cmd}.");
            }

            var argStr = arr.Length > 2 ? Base64Extensions.FromUrlSafeBase64String(arr[2]) : "{}";
            var argJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(argStr);

            return new HandlerArgs(url, cmd, arr[1].ToLower(), argJson);
        }

    }
}
