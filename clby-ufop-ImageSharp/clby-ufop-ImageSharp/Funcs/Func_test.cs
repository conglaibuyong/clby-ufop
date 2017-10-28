using clby_ufop.Core;
using clby_ufop.Core.Func;
using Microsoft.AspNetCore.Mvc;

namespace clby_ufop_ImageSharp.Funcs
{
    public class Func_test : IFunc
    {
        public IActionResult Do(byte[] fileContents, HandlerArgs args)
        {
            return new JsonResult(new
            {
                args = args
            });
        }
    }
}
