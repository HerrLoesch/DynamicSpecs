namespace DynamicSpecs.Core
{
    using System;
    
    public abstract class SpecifiesBaseState<T> : ISpecify<T>
    {
        // TODO: Refactor this part into an own class when needed
        #region Engine members
        
        protected T CreateSut()
        {
            return this.TypeResolver.Resolve<T>();
        }

        private ISupport InitializeSupportClass(ISupport supporter)
        {
            supporter.Support(this);
            return supporter;
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

        #endregion

        #region specification members

        protected abstract IRegisterTypes GetTypeRegistration();

        protected abstract IResolveTypes GetTypeResolver();
        
        public ISupport Given(ISupport supporter)
        {
            return this.InitializeSupportClass(supporter);
        }

        public virtual void Given()
        {
        }

        public virtual void When()
        {
        }

        public TMock GetInstance<TMock>()
        {
            return this.TypeResolver.Resolve<TMock>();
        }
        
        public virtual TSupport Given<TSupport>() where TSupport : ISupport
        {
            var supporter = Activator.CreateInstance<TSupport>();
            this.InitializeSupportClass(supporter);

            return supporter;
        }

        protected virtual void RegisterTypes(IRegisterTypes typeRegistration)
        {
        }

        public T SUT { get; protected set; }

        /// <summary>
        /// This method is called by the child class to call <seealso cref="SetupEachSpec"/> when
        /// ever the testing framework starts a testrun for a particular spec.
        /// </summary>
        public abstract void Setup();

        #endregion
    }
}