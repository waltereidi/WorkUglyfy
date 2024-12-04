using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Optimization;
using Uglyfy.Utility;

namespace Uglyfy
{
    
    public class BundleConfig
    {
        
        private static List<string> JSFiles { get => GetJsFiles(); }
        
        //Refers to JavaScript minification class
        private static IBundleTransform Transforms = new CustomJsUglyfy();
        public static List<string> GetJsFiles() => new List<string>()
        {
            "~/Scripts/Home/Index.js"
            ,"~/Scripts/jquery-{version}.js"
            ,"~/Scripts/modernizr-*"
            ,"~/Scripts/bootstrap.js"
        };

        /// <summary>
        /// Notice that is important to remove the file extension from the bundle name
        /// </summary>
        /// <param name="bundles"></param>
        private static void SetJavaScriptFilesToMinify(BundleCollection bundles)
            => JSFiles.ForEach( f=> bundles.Add(new CustomScriptBundle(f.Replace(".js","") ,Transforms ).Include(f)));
        

        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            SetJavaScriptFilesToMinify(bundles);
            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Enable script minification in debug mode
            BundleTable.EnableOptimizations = true;


        }

    }
}
