namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.TypebasedRegistration
{
    using DynamicSpecs.Core.WorkflowExtensions;

    using global::NUnit.Framework;

    [SetUpFixture]
    public class TypeBasedConfiguration : Extensions
    {
        [SetUp]
        public void RegisterExtensions()
        {
            this.Extend<IRequestData>().With<DataProvider>();
        }
    }
}