namespace DynamicSpecs.NUnit.Specs.BasicFeatures
{
    using DynamicSpecs.Core;
    using DynamicSpecs.NUnit;
    using DynamicSpecs.NUnit.Specs.ExampleClasses;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_specific_instance_is_configured : Specifies<DummyClass>
    {
        private DummyServiceImplementation registeredInstance;

        protected override void RegisterTypes(IRegisterTypes typeRegistration)
        {
            this.registeredInstance = new DummyServiceImplementation();
            typeRegistration.Register<DummyServiceImplementation, IAmAServiceDummy>(this.registeredInstance);
        }

        [Test]
        public void Then_the_specific_instance_must_be_returned_instead_of_a_mock()
        {
            var resultInstance = this.GetInstance<IAmAServiceDummy>();
            resultInstance.Should().BeSameAs(this.registeredInstance);
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