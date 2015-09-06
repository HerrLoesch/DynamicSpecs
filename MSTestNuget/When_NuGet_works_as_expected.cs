using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestNuget
{
    using DynamicSpecs.MSTest;

    [TestClass]
    public class When_NuGet_works_as_expected : Specifies<object>
    {
        [TestMethod]
        public void Then_this_test_should_be_green()
        {
            // TODO: Check for the library version
            Assert.IsNotNull(this.SUT);
        }
    }
}
