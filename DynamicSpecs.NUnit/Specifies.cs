namespace DynamicSpecs.NUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    using global::NUnit.Framework;

    [TestFixture]
    public abstract class Specifies<T> : SpecifiesBaseState<T>
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
    }
}
