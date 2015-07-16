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
        [ClassInitialize]
        public void Initialize(TestContext context)
        {
            base.Run();
        }

        private DummyServiceImplementation registeredInstance;

        protected override void RegisterTypes(IRegisterTypes typeRegistration)
        {
            this.registeredInstance = new DummyServiceImplementation();
            typeRegistration.Register<DummyServiceImplementation, IAmAServiceDummy>(this.registeredInstance);
        }

        [TestMethod]
        public void Then_the_specific_type_must_be_returned_instead_of_a_mock()
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
