using Microsoft.Ajax.Utilities;
using NUglify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Optimization;

namespace Uglyfy.Utility
{
    public class CustomJsUglyfy : IBundleTransform
    {
        internal static string JsContentType = "text/javascript";

        internal static readonly JsMinify Instance = new JsMinify();

        internal static void GenerateErrorResponse(BundleResponse bundle, IEnumerable<object> errors)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("/* ");
            foreach (object error in errors)
            {
                stringBuilder.Append(error.ToString()).Append("\r\n");
            }

            stringBuilder.Append(" */\r\n");
            stringBuilder.Append(bundle.Content);
            bundle.Content = stringBuilder.ToString();
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            if (!context.EnableInstrumentation)
            {
                var options = new NUglify.JavaScript.CodeSettings
                {
                    PreserveImportantComments = false, // Removes comments
                    CollapseToLiteral = true,          // Optimize object literals
                    MinifyCode = true                  // Minify the code
                };
                var uglifyResult = Uglify.Js(response.Content, options);
                response.Content = uglifyResult.Code;
                response.ContentType = "text/javascript";

            }


        }

        //
        // Resumo:
        //     Initializes a new instance of the System.Web.Optimization.JsMinify class.
        public CustomJsUglyfy()
        {
        }
    }
}
