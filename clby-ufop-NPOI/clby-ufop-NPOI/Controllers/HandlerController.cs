using clby_ufop.Core;
using clby_ufop.Core.Func;
using clby_ufop.Core.Misc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clby_ufop_NPOI.Controllers
{
    [Route("Handler")]
    public class HandlerController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var args = this.GetArgs();
            var fileContents = await this.GetFileContentsAsync();


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
            var fileContents = await this.GetFileContentsAsync();


            var func = AutofacExtensions.ResolveNamed<IFunc>($"Func_{args.Func}");
            if (func == null)
            {
                return this.StatusCode(521);
            }

            return func.Do(fileContents, args);

        }
    }
}
