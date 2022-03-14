namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_for_a_default_step : Specifies<object>, IRequestDataByDefault
    {
        public int Data { get; set; }

        public override void Given()
        {
            this.DataOfGiven = this.Data;
        }

        public int DataOfGiven { get; set; }

        [Test]
        public void Then_data_is_available_during_given_phase()
        {
            this.DataOfGiven.Should().Be(WorkflowExtensions.DataProvider.Data);
        }
    }
}