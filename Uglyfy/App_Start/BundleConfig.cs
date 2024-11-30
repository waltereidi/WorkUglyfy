using NUglify;
using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;
using Uglyfy.App_Start;

public class BundleConfig
{
    // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=303951
    public static void RegisterBundles(BundleCollection bundles)
    {
        List<IItemTransform> trans = new List<IItemTransform>();
        IItemTransform t = new MinifyHelper();
        trans.Add(t);


        var jsBundle = new Bundle("~/Scripts/Home/Index")
        .Include("~/Scripts/Home/Index.js" ,trans.ToArray());


        bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"));

        bundles.Add(new ScriptBundle("~/Scripts/Home/Index").Include(
            "~/Scripts/Home/Index.js", "~/Scripts/Home/Index.min.js"));

        // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
        // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
        bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"));

        bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js"));

        bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css"));

        // Use NUglify to minify JavaScript and CSS after bundling
        BundleTable.EnableOptimizations = true;

        //new BundleContext(new HttpContextWrapper(HttpContext.Current), bundles, "~/bundles/minified");
        jsBundle.GenerateBundleResponse(new BundleContext(new HttpContextWrapper(HttpContext.Current), bundles, "~/bundles/minified"));

        // Override the default minification behavior to use NUglify
        BundleTable.Bundles.FileSetOrderList.Clear();
        bundles.FileSetOrderList.Clear();
  
    }



}
