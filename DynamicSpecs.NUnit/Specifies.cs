namespace DynamicSpecs.NUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    using global::NUnit.Framework;

    [TestFixture]
    public class Specifies<T> : SpecifiesBaseState<T>
    {
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
            base.SetupEachSpec();
        }
    }
}
