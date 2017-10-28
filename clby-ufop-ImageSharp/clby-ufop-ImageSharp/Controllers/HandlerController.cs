using clby_ufop.Core;
using clby_ufop.Core.Func;
using clby_ufop.Core.Misc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clby_ufop_ImageSharp.Controllers
{
    [Route("Handler")]
    public class HandlerController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var args = this.GetArgs();
            var Global_MaxSize = args.Params.TryGetInt32("Global_MaxSize", HandlerHelper.MaxSize);
            var fileContents = await this.GetFileContentsAsync(Global_MaxSize);


            var func = AutofacExtensions.ResolveNamed<IFunc>($"Func_{args.Func}");
            if (func == null)
            {
                return this.StatusCode(521);
            }

            return func.Do(fileContents, args);

        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var args = this.GetArgs();
            var Global_MaxSize = args.Params.TryGetInt32("Global_MaxSize", 1024 * 1024 * 8);
            var fileContents = await this.GetFileContentsAsync(Global_MaxSize);


            var func = AutofacExtensions.ResolveNamed<IFunc>($"Func_{args.Func}");
            if (func == null)
            {
                return this.StatusCode(521);
            }

            return func.Do(fileContents, args);

        }
    }
}
