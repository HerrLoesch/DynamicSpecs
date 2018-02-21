namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.DefaultImplementationRegistration
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit;

    using FluentAssertions;

    using global::NUnit.Framework;

    [RequestType(typeof(IDefaultImplementation))]
    public class WhenATypeIsRegisteredAsDefaultImplementation : Specifies<object>
    {
        [Test]
        public void ThenTheTypeShouldBeAvailableWhenWeRequestIt()
        {
            this.GetInstance<IDefaultImplementation>().Should().BeOfType<DefaultImplemenation>();
        }
    }
}
