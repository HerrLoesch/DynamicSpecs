namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_before_when_phase : Specifies<object>, IRequestDataBeforeWhen
    {
        public int Data { get; set; }

        /// <summary>
        /// Method containing all code needed during the given phase.
        /// </summary>
        public override void When()
        {
            this.DataOfWhen = this.Data;
        }

        /// <summary>
        /// </summary>
        public int DataOfWhen { get; set; }

        [Test]
        public void Then_data_is_available_during_given_phase()
        {
            this.DataOfWhen.ShouldBeEquivalentTo(WorkflowExtensions.DataProvider.Data);
        }
    }
}