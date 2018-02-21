

namespace DynamicSpecs.MSTest
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    public class Specifies<T> : TypedWorkflowSpecification<T> where T : class
    {
        private static Specifies<T> instanceForCleanUp;

        private SpecificationEngine engine;

        protected Specifies() : base(new TypeStoreFactory()) 
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
