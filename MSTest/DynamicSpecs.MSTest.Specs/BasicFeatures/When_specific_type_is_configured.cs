namespace DynamicSpecs.MSTest.Specs.BasicFeatures
{
    using DynamicSpecs.Core;
    using DynamicSpecs.MSTest;
    using DynamicSpecs.MSTest.Specs.ExampleClasses;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class When_specific_type_is_configured : Specifies<DummyClass>
    {
        protected override void RegisterTypes(IRegisterTypes typeRegistration)
        {
            typeRegistration.Register<DummyServiceImplementation, IAmAServiceDummy>();
        }

        [TestMethod]
        public void Then_an_instance_of_the_specific_type_must_be_returned_instead_of_a_mock()
        {
            var resultInstance = this.GetInstance<IAmAServiceDummy>();
            resultInstance.Should().BeOfType<DummyServiceImplementation>();
        }

        private class DummyServiceImplementation : IAmAServiceDummy
        {
            public int DoSomething(int aParameter)
            {
                return aParameter;
            }
        }
    }
}
