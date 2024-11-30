using NUglify;
using System.IO;
using System.Web.Optimization;

namespace Uglyfy.App_Start
{

    public class NUglifyTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            
            var options = new NUglify.JavaScript.CodeSettings
            {
                PreserveImportantComments = false, // Removes comments
                CollapseToLiteral = true,          // Optimize object literals
                MinifyCode = true                  // Minify the code
            };
            var uglifyResult = Uglify.Js(response.Content, options);

            // Use NUglify to minify the JavaScript
            if (uglifyResult.Errors.Count > 0)
            {
                // Log or handle errors
                throw new InvalidDataException("NUglify failed to minify JavaScript. Errors: " +
                                               string.Join(", ", uglifyResult.Errors));
            }
            

            
            // Set the minified content
            response.Content = uglifyResult.Code;
            response.ContentType = "text/javascript";
        }
    }
}