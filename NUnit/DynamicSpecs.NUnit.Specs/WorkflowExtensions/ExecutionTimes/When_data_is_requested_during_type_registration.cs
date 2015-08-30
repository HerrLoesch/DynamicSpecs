namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExtensionsForTypeRegistration;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_before_given : ExtensionSpecsBaseStructure, IRequestDataBeforeGiven
    {
        [Test]
        public void Then_data_is_available_during_given_phase()
        {
            this.DataOfGiven.ShouldBeEquivalentTo(42);
        }
    }
}
