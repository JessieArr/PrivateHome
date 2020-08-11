using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PrivateHome.Tests.Helpers
{
    public static class ExampleExtensionHelper
    {
        private static string HelloWorldPath = "../../../../PrivateHome.DefaultExtensions/HelloWorld/HelloWorldExtension.cs";
        public static string GetHelloWorldExtension()
        {
            var contents = File.ReadAllText(HelloWorldPath);
            return contents;
        }

        private static string HttpGetPath = "../../../../PrivateHome.DefaultExtensions/HttpGet/HttpGetExtension.cs";
        public static string GetHttpGetExtension()
        {
            var contents = File.ReadAllText(HttpGetPath);
            return contents;
        }
    }
}
