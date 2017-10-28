using clby_ufop.Core;
using clby_ufop.Core.Func;
using clby_ufop.Core.Misc;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using System.Linq;

namespace clby_ufop_ImageSharp.Funcs
{
    public class Func_info : IFunc
    {

        public IActionResult Do(byte[] fileContents, HandlerArgs args)
        {
            var exif = args.Params.TryGetBoolean("exif");
            var properties = args.Params.TryGetBoolean("properties");

            using (var image = Image.Load(fileContents))
            {

                return new JsonResult(new
                {
                    size = fileContents.Length,
                    //format = "",
                    width = image.Width,
                    height = image.Height,
                    properties = properties ? null : image.MetaData.Properties.Select(t => new
                    {
                        Name = t.Name,
                        Value = t.Value
                    }),
                    exif = exif ? null : image.MetaData.ExifProfile.Values.Select(t => new
                    {
                        Name = t.Tag.ToString(),
                        Value = t.Value
                    })
                });
            }
        }

    }
}
