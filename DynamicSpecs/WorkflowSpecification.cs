namespace DynamicSpecs.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.Core.WorkflowExtensions;

    /// <summary>
    /// Base class of all specifications, handling the basic workflow.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the system under test.
    /// </typeparam>
    public abstract class WorkflowSpecification<T> : ISpecify<T> where T : class
    {
        private Type[] specificationsBaseTypes;

        /// <summary>
        /// Gets or sets an Instance of the SUT.
        /// </summary>
        public T SUT { get; protected set; }

        /// <summary>
        /// Gets or sets the instance of the central type registry.
        /// </summary>
        private IRegisterTypes TypeRegistry { get; set; }

        /// <summary>
        /// Gets or sets the instance of the central type resolver.
        /// </summary>
        private IResolveTypes TypeResolver { get; set; }

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
        /// This method is called by the child class to call <seealso cref="Run" /> when
        /// ever the testing framework starts a testrun for a particular spec.
        /// </summary>
        public abstract void Setup();

        /// <summary>
        /// Executes all needed code necessary for a test run of this instance in a particular order. 
        /// </summary>
        protected void Run()
        {
            this.DetermineTypesOfThisSpec();
            
            this.TypeRegistry = this.GetTypeRegistry();

            this.ExecuteExtensions(WorkflowPosition.TypeRegistration);

            this.RegisterTypes(this.TypeRegistry);

            this.TypeResolver = this.GetTypeResolver();

            this.ExecuteExtensions(WorkflowPosition.SUTCreation);

            this.SUT = this.CreateSut();

            this.ExecuteExtensions(WorkflowPosition.Given, WorkflowPosition.Default);

            this.Given();

            this.ExecuteExtensions(WorkflowPosition.When);

            this.When();
        }

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
        /// Creates the system Under Test and resolves all it's dependencies.
        /// </summary>
        /// <returns>Instance of the SUT.</returns>
        protected virtual T CreateSut()
        {
            return this.TypeResolver.Resolve<T>();
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
        /// <param name="targetSteps">The steps for which extensions must be registered to be executed.</param>
        private void ExecuteExtensions(params WorkflowPosition[] targetSteps)
        {
            foreach (var baseType in this.specificationsBaseTypes)
            {
                List<IExtend> extensions;
                if (Extensions.TryGetValue(baseType, out extensions))
                {
                    foreach (var extension in extensions.Where(x => targetSteps.Contains(x.WorkflowPosition)).ToList())
                    {
                        extension.Extend(this);
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
    }
}