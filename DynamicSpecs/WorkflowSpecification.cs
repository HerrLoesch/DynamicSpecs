namespace DynamicSpecs.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.Core.WorkflowExtensions;

    public abstract class WorkflowSpecification : ISpecify
    {
        private Type[] specificationsBaseTypes;

        /// <summary>
        /// Gets or sets the instance of the central type registry.
        /// </summary>
        public IRegisterTypes TypeRegistry { get; private set; }

        /// <summary>
        /// Gets or sets the instance of the central type resolver.
        /// </summary>
        protected IResolveTypes TypeResolver { get; set; }

        /// <summary>
        /// Method containing all code needed during the when phase.
        /// </summary>
        /// <param name="supporter">
        /// Class containing support code for a test run.
        /// </param>
        /// <returns>
        /// Instance of <see cref="ISupport"/>.
        /// </returns>
        public ISupport Given(ISupport supporter)
        {
            return this.InitializeSupportClass(supporter);
        }

        /// <summary>
        /// Method containing all code needed during the when phase.
        /// </summary>
        /// <param name="supporter">
        /// Class containing support code for a test run.
        /// </param>
        /// <returns>
        /// Instance of <see cref="ISupport"/>.
        /// </returns>
        public ISupport When(ISupport supporter)
        {
            return this.InitializeSupportClass(supporter);
        }

        /// <summary>
        /// Method containing all code needed during the when phase.
        /// </summary>
        public virtual void Given()
        {
        }

        /// <summary>
        /// Method containing all code needed during the when phase.
        /// </summary>
        public virtual void When()
        {
        }

        /// <summary>
        /// Resolves the instance or mock instance of a given type.
        /// </summary>
        /// <typeparam name="TInstance">Type of the instance which shall be resolved.</typeparam>
        /// <returns>Instance of the given type.</returns>
        public TInstance GetInstance<TInstance>() where TInstance : class
        {
            return this.TypeResolver.Resolve<TInstance>();
        }

        /// <summary>
        /// Executes the given support code after the SUT was instanciated and before the When phase.
        /// </summary>
        /// <typeparam name="TSupport">Type of the support class.</typeparam>
        /// <returns>Instance of the support class.</returns>
        public virtual TSupport Given<TSupport>() where TSupport : ISupport
        {
            var supporter = Activator.CreateInstance<TSupport>();
            this.InitializeSupportClass(supporter);

            return supporter;
        }

        /// <summary>
        /// Executes the given support code after the SUT was instanciated and during the Given phase.
        /// </summary>
        /// <typeparam name="TSupport">Type of the support class.</typeparam>
        /// <returns>Instance of the support class.</returns>
        public virtual TSupport Given<TSupport, T>(T supportData) where TSupport : ISupport<T>
        {
            var supporter = Activator.CreateInstance<TSupport>();
            this.InitializeSupportClass(supporter, supportData);

            return supporter;
        }

        /// <summary>
        /// Executes the given support code after the SUT was instanciated and before the When phase.
        /// </summary>
        /// <typeparam name="TSupport">Type of the support class.</typeparam>
        /// <returns>Instance of the support class.</returns>
        public virtual TSupport When<TSupport>() where TSupport : ISupport
        {
            var supporter = Activator.CreateInstance<TSupport>();
            this.InitializeSupportClass(supporter);

            return supporter;
        }

        /// <summary>
        /// Executes the given support code after the SUT was instanciated and before the When phase.
        /// </summary>
        /// <typeparam name="TSupport">Type of the support class.</typeparam>
        /// <returns>Instance of the support class.</returns>
        public virtual TSupport When<TSupport, T>(T supportData) where TSupport : ISupport<T>
        {
            var supporter = Activator.CreateInstance<TSupport>();
            this.InitializeSupportClass(supporter, supportData);

            return supporter;
        }

        /// <summary>
        /// Executes all needed code necessary for a test run of this instance in a particular order. 
        /// </summary>
        protected void Run()
        {
            this.DetermineTypesOfThisSpec();
            
            this.TypeRegistry = this.GetTypeRegistry();

            this.ExecuteExtensions(WorkflowPosition.TypeRegistration);

            this.RegisterTypes();

            this.TypeResolver = this.GetTypeResolver();

            this.ExecuteExtensions(WorkflowPosition.SUTCreation);

            if (this.WorkflowExtension != null)
            {
                this.WorkflowExtension();
            }

            this.ExecuteExtensions(WorkflowPosition.Default, WorkflowPosition.Given);
            
            this.Given();

            this.ExecuteExtensions(WorkflowPosition.When);

            this.When();
        }

        protected Action WorkflowExtension { get; set; }

        /// <summary>
        /// Gets the reference of the central type registration.
        /// </summary>
        /// <returns>
        /// The <see cref="IRegisterTypes"/>.
        /// </returns>
        protected abstract IRegisterTypes GetTypeRegistry();

        /// <summary>
        /// Gets the reference to the central instance with which types can be resolved as instances.
        /// </summary>
        /// <returns>
        /// The <see cref="IResolveTypes"/>.
        /// </returns>
        protected abstract IResolveTypes GetTypeResolver();

        private void RegisterTypes()
        {
            this.RegisterDefaultTypes();

            this.RegisterTypes(this.TypeRegistry);
        }

        private void RegisterDefaultTypes()
        {
            var typeAttributes = this.GetType().GetCustomAttributes(true);
            var typeRequests =
                typeAttributes.Where(x => x.GetType() == typeof(RequestTypeAttribute))
                    .Select(y => ((RequestTypeAttribute)y).RequestedType);
            var typesToRegister = Extensions.DefaultTypeRegistrations.Where(x => typeRequests.Any(x.IsApplicableFor));

            foreach (var distinctTypeHandler in typesToRegister)
            {
                distinctTypeHandler.Register(this.TypeRegistry);
            }
        }

        /// <summary>
        /// Registers all types needed by the SUT at a central registration or container.
        /// </summary>
        /// <param name="typeRegistration">
        /// Instance which shall contain the registered types.
        /// </param>
        protected virtual void RegisterTypes(IRegisterTypes typeRegistration)
        {
        }

        /// <summary>
        /// Contains code which hase to be executed after a spec.
        /// </summary>
        protected void OnSpecExecutionCompleted()
        {
            this.ExecuteExtensions(WorkflowPosition.SpecExecutionCompleted);
        }

        /// <summary>
        /// Contains code which has to be executed after each then phase.
        /// </summary>
        protected void OnThenIsCompleted()
        {
            this.ExecuteExtensions(WorkflowPosition.Then);
        }

        /// <summary>
        /// Executes all extensions for <c>this</c> instance based on a workflow step. 
        /// </summary>
        /// <param name="targetSteps">The steps for which an extension must be registered to be executed.</param>
        private void ExecuteExtensions(params WorkflowPosition[] targetSteps)
        {
            foreach (var baseType in this.specificationsBaseTypes)
            {
                List<IExtend> extensions;
                if (Extensions.TryGetExtension(baseType, out extensions))
                {
                    var extensionsForStep = extensions.Where(x => targetSteps.Any(y => x.WorkflowPosition.HasFlag(y))).ToList();
                    foreach (var extension in extensionsForStep)
                    {
                        foreach (var targetStep in targetSteps)
                        {
                            if (targetStep != WorkflowPosition.Default)
                            {
                                extension.Extend(this, targetStep);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Determines the types and base types of <c>this</c> spec.
        /// </summary>
        private void DetermineTypesOfThisSpec()
        {
            this.specificationsBaseTypes = this.GetType().GetInterfaces();
        }

        /// <summary>
        /// Initializes the given support class.
        /// </summary>
        /// <param name="supporter">Class which contains code to support a test run.</param>
        /// <returns>Instance of <see cref="ISupport"/></returns>
        private ISupport InitializeSupportClass(ISupport supporter)
        {
            supporter.Support(this);
            return supporter;
        }

        /// <summary>
        /// Initializes the given support class.
        /// </summary>
        /// <param name="supporter">Class which contains code to support a test run.</param>
        /// <param name="supportData">Data used during support actions.</param>
        /// <returns>Instance of <see cref="ISupport"/></returns>
        private ISupport<T> InitializeSupportClass<T>(ISupport<T> supporter, T supportData)
        {
            supporter.Support(this, supportData);
            return supporter;
        }
    }
}