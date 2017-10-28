using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clby_ufop.Core.Func
{
    public interface IFunc
    {
        IActionResult Do(byte[] fileContents, HandlerArgs args);
    }
}
