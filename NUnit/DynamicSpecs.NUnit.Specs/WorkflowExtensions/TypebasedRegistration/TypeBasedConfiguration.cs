namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.TypebasedRegistration
{
    using DynamicSpecs.Core.WorkflowExtensions;

    using global::NUnit.Framework;

    [SetUpFixture]
    public class TypeBasedConfiguration : Extensions
    {
        [OneTimeSetUp]
        public void RegisterExtensions()
        {
            Extend<IRequestData>().With<DataProvider>();
        }
    }
}