namespace DynamicSpecs.NUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    using global::NUnit.Framework;

    [TestFixture]
    public class Specifies<T> : WorkflowSpecification<T>
    {
        /// <summary>
        /// Gets or sets a container holding all registered types and can resolve mocks if no registration was made for a type.
        /// </summary>
        public TypeRegistry Registry { get; private set; }

        public Specifies()
        {
            this.Registry = new TypeRegistry();
        }

        protected override IRegisterTypes GetTypeRegistry()
        {
            return this.Registry;
        }

        protected override IResolveTypes GetTypeResolver()
        {
            return this.Registry;
        }

        [TestFixtureSetUp]
        public override void Setup()
        {
            this.Run();
        }

        [TestFixtureTearDown]
        public void AfterSpecs()
        {
            this.OnSpecExecutionCompleted();
        }
    }
}
