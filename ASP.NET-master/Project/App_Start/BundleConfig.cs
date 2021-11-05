using System.Web;
using System.Web.Optimization;

namespace Project
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
					  
					  
					  
			bundles.Add(new StyleBundle("~/assets/css").Include(
                      "~/assets/css/bootstrap-creative.min.css",
                      "~/assets/css/app-creative.min.css",
					  "~/assets/css/bootstrap-creative-dark.min.css",
					  "~/assets/css/app-creative-dark.min.css",
					  "~/assets/css/icons.min.css",
					  "~/assets/css/custom.css"
					  
					  ));
			
			bundles.Add(new ScriptBundle("~/assets/js").Include(
					"~/assets/js/vendor.min.js",
					"~/assets/libs/pace/pace.min.js",
					"~/assets/js/app.min.js"
					));



			bundles.Add(new ScriptBundle("~/asset/sms-counter").Include(										
					"~/assets/js/sms-counter.min.js"
					));






		}
    }
}
