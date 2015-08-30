namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using global::NUnit.Core;
    using global::NUnit.Framework;

    [SetUpFixture]
    public class Configuration : Extensions
    {
        [SetUp]
        public void RegisterExtensions()
        {
            this.Extend<IRequestDataBeforeTypeRegistration>().With<DataBeforeTypeRegistration>().Before(WorkflowSteps.TypeRegistration);
            this.Extend<IRequestDataBeforeGiven>().With<DataBeforeGiven>().Before(WorkflowSteps.Given);
            this.Extend<IRequestDataBeforeWhen>().With<DataBeforeWhen>().Before(WorkflowSteps.When);
        }
    }
}