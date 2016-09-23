namespace DynamicSpecs.MSTest
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class SpecifiesStatically : WorkflowSpecification
    {
        private readonly TypeRegistry typeRegistry;

        private static SpecifiesStatically instanceForCleanUp;

        protected SpecifiesStatically()
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