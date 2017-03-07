namespace DynamicSpecs.NUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    using global::NUnit.Framework;

    [TestFixture]
    public abstract class Specifies<T> : TypedWorkflowSpecification<T> where T : class
    {
        /// <summary>
        /// Gets or sets a container holding all registered types and can resolve mocks if no registration was made for a type.
        /// </summary>

        public Specifies() : base(new TypeStoreFactory())
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this.Engine.Run();
        }

        [OneTimeTearDown]
        public void AfterSpecs()
        {
            this.Engine.OnSpecExecutionCompleted();
        }

        [TearDown]
        public void AfterThenStep()
        {
            this.Engine.OnThenIsCompleted();
        }
    }
}
