namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;

    public class DefaultTypeHandler<TSource, TTarget> : IHandleDefaultTypes
        where TTarget : class
        where TSource : class, TTarget
    {
        private Type MappingTargetType { get; set; }

        private Type MappingSourceType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultTypeHandler{TSource, TTarget}"/> class.
        /// </summary>
        public DefaultTypeHandler()
        {
            this.MappingTargetType = typeof(TTarget);
            this.MappingSourceType = typeof(TSource);
        }

        /// <summary>
        /// Registers default types at the given registry.
        /// </summary>
        /// <param name="typeRegistry">The type registry at which to register default types.</param>
        public void Register(IRegisterTypes typeRegistry)
        {
            typeRegistry.Register<TSource, TTarget>();
        }

        /// <summary>
        /// Determines whether the handled type is applicable for the specific type.
        /// </summary>
        /// <param name="type">The which shall be checked.</param>
        /// <returns>
        /// True if the handled types are applicable for the specific type.
        /// </returns>
        public bool IsApplicableFor(Type type)
        {
            return type == this.MappingTargetType || type == this.MappingSourceType;
        }
    }
}