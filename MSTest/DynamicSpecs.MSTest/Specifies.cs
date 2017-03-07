

namespace DynamicSpecs.MSTest
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    public class Specifies<T> : TypedWorkflowSpecification<T> where T : class
    {
        private static Specifies<T> instanceForCleanUp;

        protected Specifies() : base(new TypeStoreFactory()) 
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
            this.Engine.OnThenIsCompleted();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            instanceForCleanUp.Engine.OnSpecExecutionCompleted();
        }
    }
}
