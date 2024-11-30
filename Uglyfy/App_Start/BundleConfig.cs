using NUglify;
using System.Web;
using System.Web.Optimization;

public class BundleConfig
{
    // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=303951
    public static void RegisterBundles(BundleCollection bundles)
    {
        // JavaScript Bundle
        bundles.Add(new ScriptBundle("~/bundles/jquery")
            .Include("~/Scripts/jquery-{version}.js"));

        // CSS Bundle
        bundles.Add(new StyleBundle("~/Content/css")
            .Include("~/Content/site.css"));

        // Use NUglify to minify JavaScript and CSS after bundling
        BundleTable.EnableOptimizations = true;

        // Override the default minification behavior to use NUglify
        BundleTable.Bundles.FileSetOrderList.Clear();
        bundles.FileSetOrderList.Clear();



       
    }
}
