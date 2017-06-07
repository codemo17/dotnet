using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace personal.tools.organizer.web.uix.App_Start
{
    public class bundleconfig
    {

        public static void registerbundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            //modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                            .Include("~/scripts/modernizr-{version}.js"));
            //jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery",
                "//ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js")
                            .Include("~/scripts/lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui",
               "//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js")
                           .Include("~/scripts/lib/jqueryui-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/lib")
                            .Include(

                                //jquery plugins

                            "~/scripts/lib/jquery.mockjson.js",

                            //third party
                            "~/scripts/lib/underscore.js",
                            "~/scripts/lib/backbone.js",
                            "~/scripts/lib/amplify.js",
                            "~/scripts/lib/jquery-ui.min.js"
                            

                     
                            )

                );

            //stub data
            bundles.Add(new ScriptBundle("~/bundles/mocks")
                            .IncludeDirectory("~/scripts/mocks", "*.js", searchSubdirectories: false)
                );

            //app

            bundles.Add(new ScriptBundle("~/bundles/app")
                            .IncludeDirectory("~/scripts/app", "*.js", searchSubdirectories: true)
                );

        }


    }
}