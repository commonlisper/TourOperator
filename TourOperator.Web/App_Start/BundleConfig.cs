using System.Threading;
using System.Web;
using System.Web.Optimization;

namespace TourOperator.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            // Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
                "~/3rdPartyComponents/tinymce/tinymce.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
                "~/Scripts/globalize/globalize.js",
                "~/Scripts/globalize/cultures/globalize.culture." + Thread.CurrentThread.CurrentCulture.Name + ".js"));

            bundles.Add(new ScriptBundle("~/bundle/solarize").Include(
                //"~/Scripts/solarize/jquery.min.js",
                "~/Scripts/solarize/jquery.dropotron.min.js",
                "~/Scripts/solarize/skel.min.js",
                "~/Scripts/solarize/skel-layers.min.js",
                "~/Scripts/solarize/init.js"));

            bundles.Add(new ScriptBundle("~/bundle/solarize/ie").Include(
                "~/Content/solarize/ie/html5shiv.js"));

            // Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Content/themes/base/all.css"));

            bundles.Add(new StyleBundle("~/Content/css/solarize").Include(
                "~/Content/solarize/skel.css",
                "~/Content/solarize/style.css"));

            bundles.Add(new StyleBundle("~/Content/css/solarize/ie").Include(
                "~/Content/solarize/ie/v8.css"));
        }
    }
}
