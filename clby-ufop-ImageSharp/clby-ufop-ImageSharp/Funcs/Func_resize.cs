using clby_ufop.Core;
using clby_ufop.Core.Func;
using clby_ufop.Core.Misc;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace clby_ufop_ImageSharp.Funcs
{
    public class Func_resize : IFunc
    {

        public IActionResult Do(byte[] fileContents, HandlerArgs args)
        {
            var o = new ResizeOptions();

            var m = args.Params.TryGetInt32("m", -1);
            var w = args.Params.TryGetInt32("w", -1);
            var h = args.Params.TryGetInt32("h", -1);
            var c = args.Params.TryGetBoolean("c", false);

            var f = args.Params.TryGetString("f", "png");
            var contentType = "image/png";
            var imageFormat = ImageFormats.Png;
            switch (f.ToLower())
            {
                case "bmp":
                    contentType = "image/bmp";
                    imageFormat = ImageFormats.Bmp;
                    break;
                case "jpg":
                case "jpeg":
                    contentType = "image/jpeg";
                    imageFormat = ImageFormats.Jpeg;
                    break;
                case "gif":
                    contentType = "image/gif";
                    imageFormat = ImageFormats.Gif;
                    break;
            }

            var base64 = args.Params.TryGetBoolean("base64", false);

            if (m > -1 && m < 6) o.Mode = (ResizeMode)m;
            if (w > 0 && h > 0) o.Size = new SixLabors.Primitives.Size(w, h);
            if (c) o.Compand = c;

            using (var image = Image.Load(fileContents))
            {
                image.Mutate(x => x
                    .Resize(o)
                    .Grayscale());

                if (!base64)
                {
                    var ms = new MemoryStream();
                    image.Save(ms, imageFormat);

                    //return new FileStreamResult(ms, contentType);

                    byte[] _fileContents = new byte[ms.Length];
                    ms.Read(_fileContents, 0, (int)ms.Length);
                    return new FileContentResult(_fileContents, contentType);

                    //return new FileContentResult(fileContents, "image/jpeg");
                }
                else
                {
                    return new JsonResult(new
                    {
                        Value = image.ToBase64String(imageFormat)
                    });
                }

            }
        }

    }
}
