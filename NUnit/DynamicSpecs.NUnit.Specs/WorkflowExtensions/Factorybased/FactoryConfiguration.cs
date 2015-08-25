namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.Factorybased
{
    using DynamicSpecs.Core.WorkflowExtensions;

    using global::NUnit.Framework;

    [SetUpFixture]
    public class FactoryConfiguration : Extensions
    {
        [SetUp]
        public void RegisterExtensions()
        {
            this.Extend<IRequestInformation>().With<IProvideInformation>(() => new InformationProvider());
        }
    }
}