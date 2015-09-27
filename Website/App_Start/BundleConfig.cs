using System.Web;
using System.Web.Optimization;

namespace Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/metisMenu.js",
                        "~/Scripts/sb-admin-2.js",
                        "~/Scripts/jquery.dataTables.js",
                        "~/Scripts/dataTables.bootstrap.js",
                        "~/Scripts/script.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/charts").Include(
                        "~/Scripts/raphael.js",
                        "~/Scripts/morris.js",
                        "~/Scripts/morris-data.js"
                        ));

            bundles.Add(new ScriptBundle("~/Scripts/svgedit/js").Include(
                        "~/Scripts/svgedit/jquery.hotkeys.min.js",
                        "~/Scripts/svgedit/jquery.bbq.min.js",
                        "~/Scripts/svgedit/jquery.svgicons.js",
                        "~/Scripts/svgedit/jquery.jgraduate.min.js",
                        "~/Scripts/svgedit/JQuerySpinBtn.min.js",
                        "~/Scripts/svgedit/touch.js",
                        "~/Scripts/svgedit/svgedit.js",
                        "~/Scripts/svgedit/jquery-svg.js",
                        "~/Scripts/svgedit/jquery.contextMenu.js",
                        "~/Scripts/svgedit/browser.js",
                        "~/Scripts/svgedit/svgtransformlist.js",
                        "~/Scripts/svgedit/math.js",
                        "~/Scripts/svgedit/units.js",
                        "~/Scripts/svgedit/svgutils.js",
                        "~/Scripts/svgedit/sanitize.js",
                        "~/Scripts/svgedit/history.js",
                        "~/Scripts/svgedit/coords.js",
                        "~/Scripts/svgedit/recalculate.js",
                        "~/Scripts/svgedit/select.js",
                        "~/Scripts/svgedit/draw.js",
                        "~/Scripts/svgedit/path.js",
                        "~/Scripts/svgedit/svgcanvas.js",
                        "~/Scripts/svgedit/svg-editor.js",
                        "~/Scripts/svgedit/locale.js",
                        "~/Scripts/svgedit/contextmenu.js",
                        "~/Scripts/svgedit/jquery-ui-1.8.17.custom.min.js",
                        "~/Scripts/svgedit/jpicker.js"
                        ));


            bundles.Add(new StyleBundle("~/Content/css/blah").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/css/metisMenu.css",
                     "~/Content/css/timeline.css",
                     "~/Content/css/sb-admin-2.css",
                     "~/Content/css/font-awesome.css",
                     "~/Content/css/dataTables.bootstrap.css",
                     "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/svgedit/styles").Include(
                     "~/Content/svgedit/jPicker.css",
                     "~/Content/svgedit/jgraduate.css",
                     "~/Content/svgedit/svg-editor.css",
                     "~/Content/svgedit/sb-admin-2.css",
                     "~/Content/svgedit/JQuerySpinBtn.css"
                     ));

            bundles.Add(new StyleBundle("~/Chart/css").Include(
                      "~/Content/morris.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
