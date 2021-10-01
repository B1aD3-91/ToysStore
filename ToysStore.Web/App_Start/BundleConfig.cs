using System.Web;
using System.Web.Optimization;

namespace ToysStore.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                "~/Scripts/jquery-3.5.1.min.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/button.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/unAjax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include( 
                "~/Content/bootstrap.min.css", 
                "~/Content/font-awesome.css", 
                "~/Content/PagedList.css",
                "~/Content/Site.css"));

        }
    }
}