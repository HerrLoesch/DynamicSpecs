namespace DynamicSpecs.NUnit.Specs.BasicFeatures
{
    using DynamicSpecs.NUnit.Specs.ExampleClasses;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_using_support_classes_during_when_phase : Specifies<DummyClass>
    {
        private int result;

        private int expectedResult;

        public override void Given()
        {
            this.expectedResult = this.Given<MockConfigurationIsProvided>().ProvidedNumber;
        }

        public override void When()
        {
            this.result = this.SUT.CallDoSomething(1);
        }

        [Test]
        public void Then_the_result_should_be_as_provided_by_the_mock()
        {
            this.result.Should().Be(this.expectedResult);
        }
    }
}