﻿using System.Web;
using System.Web.Optimization;

namespace UIDemos
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
            bundles.Add(new ScriptBundle("~/bundles/impress").Include(
            "~/Scripts/impress.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*",
						"~/Scripts/site.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/moment.js",
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/bootstrap-datetimepicker.js",
					  "~/Scripts/respond.js"));
			
			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/site.css"));
            
            bundles.Add(new ScriptBundle("~/Content/slides").Include(
            "~/Content/slides.css"));
        }
	}
}
