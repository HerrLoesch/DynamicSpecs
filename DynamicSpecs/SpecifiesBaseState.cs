namespace DynamicSpecs.Core
{
    using System;
    
    public abstract class SpecifiesBaseState<T> : ISpecify<T>
    {
        public virtual void AfterEachPart()
        {
        }

        public T SUT { get; protected set; }

        protected T CreateSut()
        {
            return this.TypeResolver.Resolve<T>();
        }

        public TMock GetInstance<TMock>()
        {
            return this.TypeResolver.Resolve<TMock>();
        }

        public virtual void Given()
        {
        }

        public virtual TSupport Given<TSupport>() where TSupport : ISupport
        {
            var supporter = Activator.CreateInstance<TSupport>();
            this.InitializeSupportClass(supporter);

            return supporter;
        }

        private ISupport InitializeSupportClass(ISupport supporter)
        {
            supporter.Support(this);
            return supporter;
        }

        public virtual void When()
        {
        }

        protected void SetupEachSpec()
        {
            this.Initialize();

            this.Given();

            this.When();
        }
        
        private void Initialize()
        {
            this.TypeRegistration = this.GetTypeRegistration();

            this.RegisterTypes(this.TypeRegistration);

            this.TypeResolver = this.GetTypeResolver();

            this.SUT = this.CreateSut();
        }

        private IRegisterTypes TypeRegistration { get; set; }

        private IResolveTypes TypeResolver { get; set; }

        public ISupport Given(ISupport supporter)
        {
            return this.InitializeSupportClass(supporter);
        }

        protected virtual void RegisterTypes(IRegisterTypes typeRegistration)
        {
        }
        
        protected abstract IRegisterTypes GetTypeRegistration();

        protected abstract IResolveTypes GetTypeResolver();
    }
}