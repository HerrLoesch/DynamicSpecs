namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;
    using System.Linq;

    /// <summary>
    /// </summary>
    /// <typeparam name="TTargetType">
    /// </typeparam>
    public class ExtensionPoint<TTargetType> : IExtend
        where TTargetType : class
    {
        /// <summary>
        /// </summary>
        public ExtensionPoint()
        {
            this.TargetType = typeof(TTargetType);
        }

        /// <summary>
        /// </summary>
        public WorkflowSteps WorkflowPosition { get; private set; }

        /// <summary>
        /// </summary>
        internal Type TargetType { get; private set; }

        /// <summary>
        /// </summary>
        internal IExtend<TTargetType> Extension { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        public void Extend(object target)
        {
            this.Extend(target as TTargetType);
        }

        /// <summary>
        /// </summary>
        /// <param name="factory">
        /// </param>
        /// <typeparam name="TExtensionType">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public ExtensionPoint<TTargetType> With<TExtensionType>(Func<TExtensionType> factory)
            where TExtensionType : IExtend<TTargetType>
        {
            this.Extension = factory.Invoke();

            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        public void Extend(TTargetType target)
        {
            this.Extension.Extend(target);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TExtensionType">
        /// </typeparam>
        /// <returns>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
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
        /// </summary>
        /// <param name="targetStep">
        /// </param>
        public void Before(WorkflowSteps targetStep)
        {
            this.WorkflowPosition = targetStep;
        }
    }
}