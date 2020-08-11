using PrivateHome.Services;
using PrivateHome.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PrivateHome.Tests.Unit
{
    public class DynamicCodeServiceTests
    {
        private DynamicCodeService SUT { get; set; }
        public DynamicCodeServiceTests()
        {
            SUT = new DynamicCodeService();
        }

        [Fact]
        public void GetAssemblyFromText_EmptyString_DoesNotThrow()
        {
            var result = SUT.GetAssemblyFromText("");
        }

        [Fact]
        public void GetAssemblyFromText_EmptyString_Succeeds()
        {
            var result = SUT.GetAssemblyFromText("");
            Assert.True(result.Succeeded);
        }

        [Fact]
        public void GetAssemblyFromText_HelloWorld_Succeeds()
        {
            var contents = ExampleExtensionHelper.GetHelloWorldExtension();
            var result = SUT.GetAssemblyFromText(contents);
            Assert.True(result.Succeeded);
        }

        [Fact]
        public void GetExtensionFromAssembly_HelloWorld_NotNull()
        {
            var contents = ExampleExtensionHelper.GetHelloWorldExtension();
            var result = SUT.GetAssemblyFromText(contents);
            var extension = SUT.GetExtensionFromAssembly(result.Assembly);
            Assert.NotNull(extension);
        }

        [Fact]
        public void GetExtensionFromAssembly_HelloWorld_SummaryReturns()
        {
            var contents = ExampleExtensionHelper.GetHelloWorldExtension();
            var result = SUT.GetAssemblyFromText(contents);
            var extension = SUT.GetExtensionFromAssembly(result.Assembly);
            var summary = extension.GetSummary();
            Assert.True(!String.IsNullOrEmpty(summary));
        }

        [Fact]
        public void GetExtensionFromAssembly_HttpGet_SummaryReturns()
        {
            var contents = ExampleExtensionHelper.GetHttpGetExtension();
            var result = SUT.GetAssemblyFromText(contents);
            var extension = SUT.GetExtensionFromAssembly(result.Assembly);
            var summary = extension.GetSummary();
            Assert.True(!String.IsNullOrEmpty(summary));
        }
    }
}
