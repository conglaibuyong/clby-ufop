using System.Collections.Generic;

namespace clby_ufop.Core
{
    public class HandlerArgs
    {
        public HandlerArgs(string url, string cmd, string func, Dictionary<string, object> pms)
        {
            ___url___ = url;
            ___cmd___ = cmd;
            Func = func;
            Params = pms;
        }

        public string ___url___ { get; }
        public string ___cmd___ { get; }
        public string Func { get; }
        public Dictionary<string, object> Params { get; }
    }
}
