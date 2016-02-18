namespace DynamicSpecs.Core.WorkflowExtensions
{
    public interface IRegisterTypesFor
    {
        /// <summary>
        /// Defines for which type the default types are registred.
        /// </summary>
        /// <typeparam name="T">Type for which to register default types.</typeparam>
        void For<T>();
    }
}