namespace DynamicSpecs.MSTest.Specs.BasicFeatures
{
    using DynamicSpecs.MSTest;
    using DynamicSpecs.MSTest.Specs.ExampleClasses;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class When_a_specification_is_created : Specifies<DummyClass>
    {
        private bool givenWasCalled;

        private bool whenWasCalled;

        public override void Given()
        {
            this.givenWasCalled = true;
        }

        public override void When()
        {
            this.whenWasCalled = true;
        }

        [TestMethod]
        public void Then_the_SUT_must_be_Initialize()
        {
            this.SUT.Should().NotBeNull();
        }

        [TestMethod]
        public void Then_the_given_phase_must_be_called()
        {
            this.givenWasCalled.Should().BeTrue();
        }

        [TestMethod]
        public void Then_the_when_phase_must_be_called()
        {
            this.whenWasCalled.Should().BeTrue();
        }
    }
}
