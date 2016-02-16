namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.DefaultImplementationRegistration
{
    using DynamicSpecs.NUnit;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class WhenATypeIsRegisteredAsDefaultImplementation : Specifies<object>, IRequestDefaultImplementation
    {
        [Test]
        public void ThenTheTypeShouldBeAvailableWhenWeRequestIt()
        {
            this.GetInstance<IDefaultImplementation>().Should().BeOfType<DefaultImplemenation>();
        }

    }
}
