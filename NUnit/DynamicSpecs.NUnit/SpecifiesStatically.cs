namespace DynamicSpecs.NUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    using global::NUnit.Framework;

    [TestFixture]
    public class SpecifiesStatically : WorkflowSpecification
    {

        public SpecifiesStatically() : base(new TypeStoreFactory())
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