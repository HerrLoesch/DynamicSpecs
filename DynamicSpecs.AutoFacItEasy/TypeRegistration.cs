namespace DynamicSpecs.AutoFacItEasy
{
    using Autofac.Extras.FakeItEasy;
    using DynamicSpecs.Core;

    public class TypeRegistration : IRegisterTypes, IResolveTypes
    {
        private readonly AutoFake fakeContainer;

        public TypeRegistration()
        {
            this.fakeContainer = new AutoFake();
        }

        void IRegisterTypes.Register<TSource, TTarget>(TSource source)
        {
            this.fakeContainer.Provide((TTarget)(object)source);
        }

        public T Resolve<T>()
        {
            return this.fakeContainer.Resolve<T>();
        }
    }
}