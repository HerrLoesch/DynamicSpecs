namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class When_data_is_requested_before_when_phase : Specifies<object>, IRequestDataBeforeWhen
    {
        public int Data { get; set; }

        public override void When()
        {
            this.DataOfWhen = this.Data;
        }

        public int DataOfWhen { get; set; }

        [TestMethod]
        public void Then_data_is_available_during_given_phase()
        {
            this.DataOfWhen.ShouldBeEquivalentTo(WorkflowExtensions.DataProvider.Data);
        }
    }
}