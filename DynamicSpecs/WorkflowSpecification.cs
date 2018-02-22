using System.Reflection;

namespace DynamicSpecs.Core
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using DynamicSpecs.Core.WorkflowExtensions;

    public abstract class WorkflowSpecification : ISpecify
    {
        private readonly ICreateTypeStores typeStoreFactory;

        public WorkflowSpecification(ICreateTypeStores typeStoreFactory)
        {
            this.typeStoreFactory = typeStoreFactory;
        }

        /// <summary>
        ///     Gets or sets the instance of the central type resolver.
        /// </summary>
        protected IResolveTypes TypeResolver { get; private set; }

        internal Action WorkflowExtension { get; set; }

        /// <summary>
        ///     Gets or sets the instance of the central type registry.
        /// </summary>
        public IRegisterTypes TypeRegistry { get; private set; }

        /// <summary>
        ///     Method containing all code needed during the when phase.
        /// </summary>
        /// <param name="supporter">
        ///     Class containing support code for a test run.
        /// </param>
        /// <returns>
        ///     Instance of <see cref="ISupport" />.
        /// </returns>
        public ISupport Given(ISupport supporter)
        {
            return InitializeSupportClass(supporter);
        }

        /// <summary>
        ///     Method containing all code needed during the when phase.
        /// </summary>
        /// <param name="supporter">
        ///     Class containing support code for a test run.
        /// </param>
        /// <returns>
        ///     Instance of <see cref="ISupport" />.
        /// </returns>
        public ISupport When(ISupport supporter)
        {
            return InitializeSupportClass(supporter);
        }

        /// <summary>
        ///     Method containing all code needed during the given phase.
        /// </summary>
        public virtual void Given()
        {
        }

        /// <summary>
        ///     Method containing all code needed during the when phase.
        /// </summary>
        public virtual void When()
        {
        }

        /// <summary>
        ///     Resolves the instance or mock instance of a given type.
        /// </summary>
        /// <typeparam name="TInstance">Type of the instance which shall be resolved.</typeparam>
        /// <returns>Instance of the given type.</returns>
        public TInstance GetInstance<TInstance>() where TInstance : class
        {
            return TypeResolver.Resolve<TInstance>();
        }

        /// <summary>
        ///     Executes the given support code after the SUT was instanciated and during the Given phase.
        /// </summary>
        /// <typeparam name="TSupport">Type of the support class.</typeparam>
        /// <returns>Instance of the support class.</returns>
        public virtual TSupport Given<TSupport, T>(T supportData) where TSupport : ISupport<T>
        {
            var supporter = Activator.CreateInstance<TSupport>();
            InitializeSupportClass(supporter, supportData);

            return supporter;
        }

        /// <summary>
        ///     Executes the given support code after the SUT was instanciated and before the When phase.
        /// </summary>
        /// <typeparam name="TSupport">Type of the support class.</typeparam>
        /// <returns>Instance of the support class.</returns>
        public virtual TSupport When<TSupport, T>(T supportData) where TSupport : ISupport<T>
        {
            var supporter = Activator.CreateInstance<TSupport>();
            InitializeSupportClass(supporter, supportData);

            return supporter;
        }

        internal void Initialize()
        {
            TypeRegistry = typeStoreFactory.GetTypeRegistry();
            TypeResolver = typeStoreFactory.GetTypeResolver();
        }

        /// <summary>
        ///     Method containing all code needed during the given phase. This is executed after void Given()
        /// </summary>
        /// <returns>awaitable Task</returns>
        public virtual Task GivenAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        ///     Method containing all code needed during the when phase. This is executed after void When()
        /// </summary>
        public virtual Task WhenAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        ///     Executes the given support code after the SUT was instanciated and before the When phase.
        /// </summary>
        /// <typeparam name="TSupport">Type of the support class.</typeparam>
        /// <returns>Instance of the support class.</returns>
        public virtual TSupport Given<TSupport>() where TSupport : ISupport
        {
            var supporter = Activator.CreateInstance<TSupport>();
            InitializeSupportClass(supporter);

            return supporter;
        }

        /// <summary>
        ///     Executes the given support code after the SUT was instanciated and before the When phase.
        /// </summary>
        /// <typeparam name="TSupport">Type of the support class.</typeparam>
        /// <returns>Instance of the support class.</returns>
        public virtual TSupport When<TSupport>() where TSupport : ISupport
        {
            var supporter = Activator.CreateInstance<TSupport>();
            InitializeSupportClass(supporter);

            return supporter;
        }

        internal void RegisterTypes()
        {
            RegisterDefaultTypes();

            RegisterTypes(TypeRegistry);
        }

        private void RegisterDefaultTypes()
        {
            var typeAttributes = this.GetType().GetTypeInfo().GetCustomAttributes(typeof(RequestTypeAttribute), true);
            var typeRequests = typeAttributes.Select(y => ((RequestTypeAttribute)y).RequestedType).ToList();
            var typesToRegister = Extensions.DefaultTypeRegistrations.Where(x => typeRequests.Any(x.IsApplicableFor));

            foreach (var distinctTypeHandler in typesToRegister)
                distinctTypeHandler.Register(TypeRegistry);
        }

        /// <summary>
        ///     Registers all types needed by the SUT at a central registration or container.
        /// </summary>
        /// <param name="typeRegistration">
        ///     Instance which shall contain the registered types.
        /// </param>
        protected virtual void RegisterTypes(IRegisterTypes typeRegistration)
        {
        }

        /// <summary>
        ///     Initializes the given support class.
        /// </summary>
        /// <param name="supporter">Class which contains code to support a test run.</param>
        /// <returns>Instance of <see cref="ISupport" /></returns>
        private ISupport InitializeSupportClass(ISupport supporter)
        {
            supporter.Support(this);
            return supporter;
        }

        /// <summary>
        ///     Initializes the given support class.
        /// </summary>
        /// <param name="supporter">Class which contains code to support a test run.</param>
        /// <param name="supportData">Data used during support actions.</param>
        /// <returns>Instance of <see cref="ISupport" /></returns>
        private ISupport<T> InitializeSupportClass<T>(ISupport<T> supporter, T supportData)
        {
            supporter.Support(this, supportData);
            return supporter;
        }
    }
}