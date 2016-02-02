using System.Web.Optimization;

namespace WebLayer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui.js",
                "~/Scripts/jQuery.FileUpload/jquery.ui.widget.js",
                "~/Scripts/jQuery.FileUpload/jquery.iframe-transport.js",
                "~/Scripts/jQuery.FileUpload/jquery.fileupload.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/holy").Include(
                "~/Scripts/holystream/holystream.js")
              .IncludeDirectory("~/Scripts/Holystream", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(                
                "~/Content/bootstrap.css",
                "~/Content/jquery-ui.css",
                "~/Content/jquery-ui.structure.css",
                "~/Content/jquery-ui.theme.css",
                "~/Content/jquery.fileupload.css", //CSS to style the file input field as button and adjust the Bootstrap progress bars 
                "~/Content/jquery.fileupload-ui.css",
                "~/Content/site.css",
                "~/Content/HolyStream/holystream.css",
                "~/Content/font-awesome.css"
                ));
        }
    }
}