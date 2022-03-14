namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class When_data_is_requested_before_given_phase : Specifies<object>, IRequestDataBeforeGiven
    {
        public int Data { get; set; }

        public override void Given()
        {
            this.DataOfGiven = this.Data;
        }

        public int DataOfGiven { get; set; }

        [TestMethod]
        public void Then_data_is_available_during_given_phase()
        {
            this.DataOfGiven.Should().Be(WorkflowExtensions.DataProvider.Data);
        }
    }
}