using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clby_ufop.Core.Func
{
    public interface IFuncAsync
    {
        Task<IActionResult> DoAsync(byte[] fileContents, HandlerArgs args);
    }
}
