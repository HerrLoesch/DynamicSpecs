namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;
    using System.Linq;

    /// <summary>
    /// Particular extension point during the execution flow of a particular specification.
    /// </summary>
    /// <typeparam name="TTargetType">
    /// Type to extend.
    /// </typeparam>
    public class ExtensionPoint<TTargetType> : IExtend
        where TTargetType : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionPoint{TTargetType}"/> class.
        /// </summary>
        public ExtensionPoint()
        {
            this.TargetType = typeof(TTargetType);
        }
        
        /// <summary>
        /// Gets the step of the execution workflow of a specification at which the extension needs to be applied.
        /// </summary>
        public WorkflowPosition WorkflowPosition { get; private set; }

        /// <summary>
        /// Gets or sets the type of the target.
        /// </summary>
        /// <value>
        /// The type of the target.
        /// </value>
        private Type TargetType { get; set; }

        /// <summary>
        /// Gets or sets the actual instance of the extension class.
        /// </summary>
        /// <value>
        /// The instance of the actual extension.
        /// </value>
        private IExtend<TTargetType> Extension { get; set; }
        
        /// <summary>
        /// Executes the code which actually extends the specified target.
        /// </summary>
        /// <param name="target">
        /// The target to extend.
        /// </param>
        public void Extend(object target)
        {
            this.Extend(target as TTargetType);
        }

        /// <summary>
        /// Registers an instance of an extension created by the given factory method.
        /// </summary>
        /// <typeparam name="TExtensionType">
        /// The type of the extension.
        /// </typeparam>
        /// <param name="factory">
        /// The factory method with which the extension can be created.
        /// </param>
        /// <returns>
        /// Instance of the ExtensionPoint with which the extension can be configured furthermore.
        /// </returns>
        public ExtensionPoint<TTargetType> With<TExtensionType>(Func<TExtensionType> factory)
            where TExtensionType : IExtend<TTargetType>
        {
            this.Extension = factory.Invoke();

            return this;
        }

        /// <summary>
        /// Creates an instance of the given extension type.
        /// </summary>
        /// <typeparam name="TExtensionType">The type of the extension.</typeparam>
        /// <returns>
        /// Instance of the ExtensionPoint with which the extension can be configured furthermore.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">No default constructor found. Extensions need default constructors or must be registered with a factory.</exception>
        public ExtensionPoint<TTargetType> With<TExtensionType>() where TExtensionType : IExtend<TTargetType>
        {
            var type = typeof(TExtensionType);
            var defaultConstructor = type.GetConstructors().FirstOrDefault(x => x.GetParameters().Length == 0);

            if (defaultConstructor == null)
            {
                throw new InvalidOperationException(
                    "No default constructor found. Extensions need default constructors or must be registered with a factory.");
            }

            this.Extension = defaultConstructor.Invoke(new object[0]) as IExtend<TTargetType>;

            return this;
        }

        /// <summary>
        /// Configures before which step to run the extension.
        /// </summary>
        /// <param name="targetStep">The step before which to run the extension.</param>
        public void Before(WorkflowPosition targetStep)
        {
            this.WorkflowPosition = targetStep;
        }
        
        /// <summary>
        /// Executes the encapsulated extension for the given target instance.
        /// </summary>
        /// <param name="target">
        /// The target instance.
        /// </param>
        private void Extend(TTargetType target)
        {
            this.Extension.Extend(target);
        }
    }
}