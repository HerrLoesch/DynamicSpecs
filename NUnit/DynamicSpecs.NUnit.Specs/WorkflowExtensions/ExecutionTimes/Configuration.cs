namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.Core;
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using global::NUnit.Framework;

    [SetUpFixture]
    public class Configuration : Extensions
    {
        [SetUp]
        public void RegisterExtensions()
        {
            this.Extend<IRequestDataByDefault>().With<DataByDefault>();

            this.Extend<IRequestDataBeforeTypeRegistration>().With<DataBeforeTypeRegistration>().Before(WorkflowPosition.TypeRegistration);
            this.Extend<IRequestDataBeforeSUTCreation>().With<DataBeforeSUTCreation>().Before(WorkflowPosition.SUTCreation);

            this.Extend<IRequestDataBeforeGiven>().With<DataBeforeGiven>().Before(WorkflowPosition.Given);
            this.Extend<IRequestDataBeforeWhen>().With<DataBeforeWhen>().Before(WorkflowPosition.When);
        }
    }
}