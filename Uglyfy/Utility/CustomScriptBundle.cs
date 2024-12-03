using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Uglyfy.Utility
{
    public class CustomScriptBundle : Bundle
    {
        //
        // Resumo:
        //     Initializes a new instance of the System.Web.Optimization.ScriptBundle class
        //     that takes a virtual path for the bundle.
        //
        // Parâmetros:
        //   virtualPath:
        //     The virtual path for the bundle.

        public CustomScriptBundle(string virtualPath , IBundleTransform transform )
            :base(virtualPath, transform)
        {
        }

        //
        // Resumo:
        //     Initializes a new instance of the System.Web.Optimization.ScriptBundle class
        //     that takes virtual path and cdnPath for the bundle.
        //
        // Parâmetros:
        //   virtualPath:
        //     The virtual path for the bundle.
        //
        //   cdnPath:
        //     The path of a Content Delivery Network (CDN).
        public CustomScriptBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath, new CustomJsUglyfy())
        {
            base.ConcatenationToken = ";" + Environment.NewLine;
        }
    }
}