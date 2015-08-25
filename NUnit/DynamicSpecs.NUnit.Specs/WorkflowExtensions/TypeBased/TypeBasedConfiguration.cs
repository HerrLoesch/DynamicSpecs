namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.TypeBased
{
    using DynamicSpecs.Core.WorkflowExtensions;

    using global::NUnit.Framework;

    [SetUpFixture]
    public class TypeBasedConfiguration : Extensions
    {
        [SetUp]
        public void RegisterExtensions()
        {
            this.Extend<IRequestInformation>().With<InformationProvider>();
        }
    }
}