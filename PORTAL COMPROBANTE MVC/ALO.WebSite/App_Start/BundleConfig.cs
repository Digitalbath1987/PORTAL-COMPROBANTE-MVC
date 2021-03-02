using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ALO.WebSite.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-3.2.1.min.js")
            );

            bundles.Add(new ScriptBundle("~/Scripts/Bootstrap").Include(
                 "~/Scripts/bootstrap.min.js")
            );

            bundles.Add(new StyleBundle("~/Content/Bootstrap").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-theme.min.css")
            );
            bundles.Add(new StyleBundle("~/Content/Default").Include(
                "~/Content/Default.css")
           );
        }

    }
}