using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace clby_ufop.Core.Misc
{
    [DebuggerStepThrough]
    public static class ControllerExtensions
    {
        public static string GetValue(this Controller controller, string key)
        {
            var values = controller.Request.Query[key];
            if (values.Any())
            {
                return values[0];
            }
            if (controller.Request.HasFormContentType)
            {
                values = controller.Request.Form[key];
                if (values.Any())
                {
                    return values[0];
                }
            }
            values = controller.Request.Cookies[key];
            if (values.Any())
            {
                return values[0];
            }
            return null;
        }

        public static string GetStringParameter(this Controller controller, string key, string defaultValue = "")
        {
            return controller.GetValue(key) ?? defaultValue;
        }

        public static bool GetBooleanParameter(this Controller controller, string key)
        {
            var value = controller.GetValue(key);
            Ensure.IsNotNullOrEmpty(value, key);
            return "true".Equals(value.ToLower());
        }
        public static bool TryGetBooleanParameter(this Controller controller, string key, bool defaultValue = false)
        {
            var value = controller.GetValue(key) ?? (defaultValue ? "true" : "false");
            return "true".Equals(value.ToLower());
        }

        public static int GetIntParameter(this Controller controller, string key)
        {
            var value = controller.GetValue(key);
            Ensure.IsNotNullOrEmpty(value, key);
            int intValue;
            if (int.TryParse(value, out intValue))
            {
                return intValue;
            }
            else
            {
                throw new ArgumentException("Value cannot be empty.", key);
            }
        }
        public static int TryGetIntParameter(this Controller controller, string key, int defaultValue = 0)
        {
            var value = controller.GetValue(key);
            int intValue = defaultValue;
            int.TryParse(value, out intValue);
            return intValue;
        }

        public static double GetDoubleParameter(this Controller controller, string key)
        {
            var value = controller.GetValue(key);
            Ensure.IsNotNullOrEmpty(value, key);
            double doubleValue;
            if (double.TryParse(value, out doubleValue))
            {
                return doubleValue;
            }
            else
            {
                throw new ArgumentException("Value cannot be empty.", key);
            }
        }
        public static double TryGetDoubleParameter(this Controller controller, string key, double defaultValue = 0)
        {
            var value = controller.GetValue(key);
            double doubleValue = defaultValue;
            double.TryParse(value, out doubleValue);
            return doubleValue;
        }


        public static IActionResult JsonEx(this Controller controller, bool result, string msg = "", object json = null)
        {
            var value = new
            {
                result = result,
                msg = msg,
                json = json
            };
            return controller.Json(value);

        }
    }
}
