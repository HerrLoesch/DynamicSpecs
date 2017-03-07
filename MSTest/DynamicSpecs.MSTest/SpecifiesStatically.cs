namespace DynamicSpecs.MSTest
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class SpecifiesStatically : WorkflowSpecification
    {

        private static SpecifiesStatically instanceForCleanUp;

        protected SpecifiesStatically() : base(new TypeStoreFactory())
        {
            instanceForCleanUp = this;
        }

        [TestInitialize]
        public void Setup()
        {
            base.Engine.Run();
        }

        [TestCleanup]
        public void StepwiseCleanup()
        {
            Engine.OnThenIsCompleted();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            instanceForCleanUp.Engine.OnSpecExecutionCompleted();
        }
    }
}