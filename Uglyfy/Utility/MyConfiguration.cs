using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Uglyfy.Utility
{
    public static class MyConfiguration
    {
        public static string JavascriptMinPath { get { return WebConfigurationManager.AppSettings["javascriptMinPath"].ToString() 
                    ?? throw new NullReferenceException("javascriptMinPath is not defined"); } }

        public static string JavascriptRootPath { get { return WebConfigurationManager.AppSettings["javascriptRootPath"].ToString() 
                    ?? throw new NullReferenceException("javascriptRootPath is not defined");  } }
    }
}