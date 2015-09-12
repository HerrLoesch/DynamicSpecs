

namespace DynamicSpecs.MSTest
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class Specifies<T> : WorkflowSpecification<T>
    {
        private readonly TypeRegistry typeRegistry;
        
        protected Specifies()
        {
            this.typeRegistry = new TypeRegistry();
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
        public void CleanUp()
        {
            this.OnSpecExecutionCompleted();
        }
    }
}
