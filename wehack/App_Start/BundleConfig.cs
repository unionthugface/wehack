using System.Web;
using System.Web.Optimization;

namespace wehack
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.ajaxchimp.min.js",
                        "~/Scripts/jquery.easing.1.3.js",
                        "~/Scripts/jquery.magnific-popup.min.js",
                        "~/Scripts/jquery.particleground.min.js",
                        "~/Scripts/jquery.stellar.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/angular-*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/wehack").Include(
                    "~/Scripts/wehack.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                    "~/Scripts/theme/custom.js",
                    "~/Scripts/theme/owl.carousel.min.js",
                    "~/Scripts/theme/scrollIt.js",
                    "~/Scripts/theme/swiper.min.js",
                    "~/Scripts/theme/wow.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/theme").Include(
                      "~/Content/theme/animate.css",
                      //"~/Content/theme/font-awesome.min.css",
                      "~/Content/theme/magnific-popup.css",
                      "~/Content/theme/media.css",
                      "~/Content/theme/owl.carousel.css",
                      "~/Content/theme/owl.theme.css",
                      //"~/Content/theme/style-blue.css",
                      "~/Content/theme/style-green.css",
                      //"~/Content/theme/style-orange.css",
                      //"~/Content/theme/style-pink.css",
                      //"~/Content/theme/style-red.css",
                      "~/Content/theme/swiper.css"
                      ));
        }
    }
}
