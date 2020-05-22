namespace DynamicSpecs.Core
{
    /// <summary>
    /// Defines how registered type are resolved.
    /// </summary>
    public interface IResolveTypes
    {
        /// <summary>
        /// Resolves an instance of the given type.
        /// </summary>
        /// <typeparam name="T">Type to resolve.</typeparam>
        /// <returns>Instance of type T</returns>
        T Resolve<T>() where T : class;
    }
}