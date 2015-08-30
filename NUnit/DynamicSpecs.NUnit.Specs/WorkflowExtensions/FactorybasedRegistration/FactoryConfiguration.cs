namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.FactorybasedRegistration
{
    using DynamicSpecs.Core.WorkflowExtensions;

    using global::NUnit.Framework;

    [SetUpFixture]
    public class FactoryConfiguration : Extensions
    {
        [SetUp]
        public void RegisterExtensions()
        {
            Extend<IRequestData>().With<IProvideData>(() => new DataProvider());
        }
    }
}