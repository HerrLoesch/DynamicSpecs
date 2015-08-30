

namespace DynamicSpecs.MSTest
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class Specifies<T> : WorkflowSpecification<T>
    {
        private readonly TypeRegistration typeRegistration;
        
        protected Specifies()
        {
            this.typeRegistration = new TypeRegistration();
        }

        protected override IRegisterTypes GetTypeRegistration()
        {
            return this.typeRegistration;
        }

        protected override IResolveTypes GetTypeResolver()
        {
            return this.typeRegistration;
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Run();
        }
    }
}
