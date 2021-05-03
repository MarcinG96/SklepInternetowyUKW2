using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SklepUKW.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js", "~/Scripts/jquery-ui-{version}.js"));
            bundles.Add(new StyleBundle("~/themes/base/css").Include("~/themes/base/core.css", "~/themes/base/autocomplete.css", "~/themes/base/theme.css", "~/themes/base/menu.css"));

        }
    }
}