namespace DynamicSpecs.NUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    using global::NUnit.Framework;

    [TestFixture]
    public class SpecifiesStatically : WorkflowSpecification
    {
        private readonly SpecificationEngine engine;

        public SpecifiesStatically() : base(new TypeStoreFactory())
        {
            this.engine = new SpecificationEngine(this);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this.engine.Run();
        }

        [OneTimeTearDown]
        public void AfterSpecs()
        {
            this.engine.OnSpecExecutionCompleted();
        }

        [TearDown]
        public void AfterThenStep()
        {
            this.engine.OnThenIsCompleted();
        }
    }
}