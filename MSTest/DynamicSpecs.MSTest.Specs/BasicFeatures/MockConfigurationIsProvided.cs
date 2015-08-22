namespace DynamicSpecs.MSTest.Specs.BasicFeatures
{
    using DynamicSpecs.Core;
    using DynamicSpecs.MSTest.Specs.ExampleClasses;

    using FakeItEasy;

    public class MockConfigurationIsProvided : ISupport
    {
        public int ProvidedNumber { get; private set; }

        public void Support(ISpecify specification)
        {
            this.ProvidedNumber = 3;

            var mock = specification.GetInstance<IAmAServiceDummy>();
            A.CallTo(() => mock.DoSomething(1)).Returns(this.ProvidedNumber);
        }
    }
}