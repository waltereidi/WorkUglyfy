using NUglify;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using Uglyfy.App_Start;
using Uglyfy.Utility;

public class BundleConfig
{
    /// <summary>
    /// Add here your javascript files, notice that all files here will be minified,<br></br>
    /// Use js relative paths 
    /// </summary>
    /// <returns></returns>
    public static List<string> GetJavascriptFiles()
    {
        List<string> files = new List<string>();
        
        files.Add("/Home/Index.js");

        return files;
    }
    public List<string> GetRootPathJavascriptFiles(List<string> files) => files
        .Select(f => f = $"{MyConfiguration.JavascriptRootPath}{f}")
        .ToList();
        
    public List<string> GetUglyfyPathJavascriptFiles(List<string> files) => files
        .Select(f => f = $"{MyConfiguration.JavascriptMinPath}{f}")
        .ToList();

    /// <summary>
    /// Here your scripts will be minified.
    /// </summary>
    /// <returns></returns>
    public static void SetJavaScriptBundle(BundleCollection bundles)
    {
        GetJavascriptFiles()
            .ForEach(f =>
            {
                var jsBundle = new Bundle($"{MyConfiguration.JavascriptRootPath}{f}");
                jsBundle.Include($"{MyConfiguration.JavascriptRootPath}{f}", new NuglyfyJsTransform());
                jsBundle.GenerateBundleResponse(new BundleContext(new HttpContextWrapper(HttpContext.Current), bundles, MyConfiguration.JavascriptRootPath));
                bundles.Add(jsBundle);
            });
    }


    public static void RegisterBundles(BundleCollection bundles)
    {
        SetJavaScriptBundle(bundles);
        //bundles.Add(new ScriptBundle("~/Scripts/Home/Index").Include(
        //    "~/Scripts/Home/Index.js", "~/Scripts/Home/Index.min.js"));

        //// Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
        //// pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
        ////bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
        ////            "~/Scripts/modernizr-*"));

        //bundles.Add(new Bundle("~/bundles/bootstrap").Include(
        //          "~/Scripts/bootstrap.js"));

        //bundles.Add(new StyleBundle("~/Content/css").Include(
        //          "~/Content/bootstrap.css",
        //          "~/Content/site.css"));


        // Use NUglify to minify JavaScript and CSS after bundling
        BundleTable.EnableOptimizations = true;

        //new BundleContext(new HttpContextWrapper(HttpContext.Current), bundles, "~/bundles/minified");

        // Override the default minification behavior to use NUglify
        BundleTable.Bundles.FileSetOrderList.Clear();
        bundles.FileSetOrderList.Clear();
  
    }



}
