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
        public TypeRegistration Registration { get; private set; }

        public Specifies()
        {
            this.Registration = new TypeRegistration();
        }

        protected override IRegisterTypes GetTypeRegistration()
        {
            return this.Registration;
        }

        protected override IResolveTypes GetTypeResolver()
        {
            return this.Registration;
        }

        [TestFixtureSetUp]
        public override void Setup()
        {
            this.Run();
        }

        [TearDown]
        public void AfterSpecs()
        {
            this.OnSpecExecutionCompleted();
        }
    }
}
