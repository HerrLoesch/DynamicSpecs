using DynamicSpecs.Core.WorkflowExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions.DefaultImplementationRegistration
{
    [TestClass]
    [RequestType(typeof(IDefaultImplementation))]
    public class WhenATypeIsRegisteredAsDefaultImplementation : Specifies<object>
    {
        [TestMethod]
        public void ThenTheTypeShouldBeAvailableWhenWeRequestIt()
        {
            this.GetInstance<IDefaultImplementation>().Should().BeOfType<DefaultImplemenation>();
        }
    }
}
