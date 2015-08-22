namespace DynamicSpecs.Core
{
    /// <summary>
    /// Specifies the structures of a type registration.
    /// </summary>
    public interface IRegisterTypes
    {
        /// <summary>
        /// Registers an instance as a target type.
        /// </summary>
        /// <typeparam name="TSource">Source type which is registered.</typeparam>
        /// <typeparam name="TTarget">Target type as which the source type is used.</typeparam>
        /// <param name="source">Registered instance.</param>
        void Register<TSource, TTarget>(TSource source) 
            where TSource : class, TTarget
            where TTarget : class;
        
        /// <summary>
        /// Registers a type as a target type.
        /// </summary>
        /// <typeparam name="TSource">Source type which is registered.</typeparam>
        /// <typeparam name="TTarget">Target type as which the source type is used.</typeparam>
        void Register<TSource, TTarget>()
            where TSource : class, TTarget
            where TTarget : class;
    }
}