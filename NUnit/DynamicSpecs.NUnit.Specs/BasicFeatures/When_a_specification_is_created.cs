using System.Threading.Tasks;

namespace DynamicSpecs.NUnit.Specs.BasicFeatures
{
    using DynamicSpecs.NUnit.Specs.ExampleClasses;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_a_specification_is_created : Specifies<DummyClass>
    {
        private System.Collections.Generic.List<CallStep> callSteps = new global::System.Collections.Generic.List<CallStep>();

        private enum CallStep
        {
            Given,
            GivenAsync,
            When,
            WhenAsync,
            Then
        }



        public override void Given()
        {
            this.callSteps.Add(CallStep.Given);
        }

        public override async Task GivenAsync()
        {
            await Task.Delay(100); //Simulate a long running task
            this.callSteps.Add(CallStep.GivenAsync);
        }

        public override void When()
        {
            this.callSteps.Add(CallStep.When);
        }

        public override async Task WhenAsync()
        {
            await Task.Delay(100); //Simulate a long running task
            this.callSteps.Add(CallStep.WhenAsync);
        }

        [Test]
        public void Then_the_SUT_must_be_Initialize()
        {
            this.SUT.Should().NotBeNull();
        }

        [Test]
        public void Then_the_given_phase_must_be_called()
        {
            this.callSteps.Should().Contain(CallStep.Given);
        }

        [Test]
        public void Then_the_when_phase_must_be_called()
        {
            this.callSteps.Should().Contain(CallStep.When);
        }

        [Test]
        public void Then_phases_are_in_the_right_order()
        {
            callSteps.Add(CallStep.Then);
            this.callSteps.Should().Equal(CallStep.Given, CallStep.GivenAsync, CallStep.When, CallStep.WhenAsync,
                                          CallStep.Then);
        }
    }
}
