namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_before_given_phase : Specifies<object>, IRequestDataBeforeGiven
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