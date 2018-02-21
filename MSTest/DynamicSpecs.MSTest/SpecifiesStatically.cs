namespace DynamicSpecs.MSTest
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class SpecifiesStatically : WorkflowSpecification
    {

        private static SpecifiesStatically instanceForCleanUp;
        private SpecificationEngine engine;

        protected SpecifiesStatically() : base(new TypeStoreFactory())
        {
            instanceForCleanUp = this;
            this.engine = new SpecificationEngine(this);
        }

        [TestInitialize]
        public void Setup()
        {
            this.engine.Run();
        }

        [TestCleanup]
        public void StepwiseCleanup()
        {
            this.engine.OnThenIsCompleted();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            instanceForCleanUp.engine.OnSpecExecutionCompleted();
        }
    }
}