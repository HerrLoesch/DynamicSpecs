namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ConfigureTypeRegistration
{
    using DynamicSpecs.Core;
    using DynamicSpecs.Core.WorkflowExtensions;

    using global::NUnit.Framework;

    [SetUpFixture]
    public class FactoryConfiguration : Extensions
    {
        [OneTimeSetUp]
        public void RegisterExtensions()
        {
            Extend<ISpecify>().With<TypeProvider>();
        }
    }
}
