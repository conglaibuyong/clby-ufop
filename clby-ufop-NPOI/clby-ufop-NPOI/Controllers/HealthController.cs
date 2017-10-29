using Microsoft.AspNetCore.Mvc;
using clby_ufop.Core.Misc;

namespace clby_ufop_NPOI.Controllers
{
    [Route("Health")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return this.JsonEx(true);
        }

    }
}
