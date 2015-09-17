namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_during_differnt_steps : Specifies<object>, IRequestStatelessData
    {
        public int GivenData { get; set; }

        public int WhenData { get; set; }

        /// <summary>
        /// Method containing all code needed during the when phase.
        /// </summary>
        public override void Given()
        {
            this.GivenData.ShouldBeEquivalentTo(StatelessMultipleDataProvider.GivenData);
        }

        [Test]
        public void Then_the_data_is_provided_during_each_configured_step()
        {
            this.WhenData.ShouldBeEquivalentTo(StatelessMultipleDataProvider.WhenData);
        }
    }
}