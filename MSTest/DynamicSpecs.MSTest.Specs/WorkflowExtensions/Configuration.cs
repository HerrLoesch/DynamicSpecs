
using DynamicSpecs.MSTest.Specs.WorkflowExtensions.DefaultImplementationRegistration;

namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.DataProvider;
    using DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Configuration : Extensions
    {
        [AssemblyInitialize]
        public static void RegisterExtensions(TestContext context)
        {
            Provide<DefaultImplemenation, IDefaultImplementation>();

            Extend<IRequestDataByDefault>().With<DataByDefault>();

            Extend<IRequestDataBeforeTypeRegistration>().With<DataBeforeTypeRegistration>().Before(WorkflowPosition.TypeRegistration);
            Extend<IRequestDataBeforeSUTCreation>().With<DataBeforeSUTCreation>().Before(WorkflowPosition.SUTCreation);

            Extend<IRequestDataBeforeGiven>().With<DataBeforeGiven>().Before(WorkflowPosition.Given);
            Extend<IRequestDataBeforeWhen>().With<DataBeforeWhen>().Before(WorkflowPosition.When);
        }
    }
}
