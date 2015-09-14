

namespace DynamicSpecs.MSTest
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class Specifies<T> : WorkflowSpecification<T> where T : class
    {
        private readonly TypeRegistry typeRegistry;

        private static Specifies<T> instanceForCleanUp;

        protected Specifies()
        {
            this.typeRegistry = new TypeRegistry();
            instanceForCleanUp = this;
        }

        protected override IRegisterTypes GetTypeRegistry()
        {
            return this.typeRegistry;
        }

        protected override IResolveTypes GetTypeResolver()
        {
            return this.typeRegistry;
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Run();
        }

        [TestCleanup]
        public void StepwiseCleanup()
        {
            this.OnThenIsCompleted();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            instanceForCleanUp.OnSpecExecutionCompleted();
        }
    }
}
