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
            Extend<IRequestDataByDefault>().With<DataByDefault>();

            Extend<IRequestDataBeforeTypeRegistration>().With<DataBeforeTypeRegistration>().Before(WorkflowPosition.TypeRegistration);
            Extend<IRequestDataBeforeSUTCreation>().With<DataBeforeSUTCreation>().Before(WorkflowPosition.SUTCreation);
            Extend<IRequestDataBeforeGiven>().With<DataBeforeGiven>().Before(WorkflowPosition.Given);
            Extend<IRequestDataBeforeWhen>().With<DataBeforeWhen>().Before(WorkflowPosition.When);
            Extend<IRequestDataBeforeThenIsCompleted>().With<DataBeforeThenIsCompleted>().Before(WorkflowPosition.Then);

            Extend<IRequestStatefullData>().With<StatefullMultipleDataProvider>().Before(WorkflowPosition.Given | WorkflowPosition.When);
            Extend<IRequestStatelessData>().With<StatelessMultipleDataProvider>().Before(WorkflowPosition.Given | WorkflowPosition.When);
        }
    }
}