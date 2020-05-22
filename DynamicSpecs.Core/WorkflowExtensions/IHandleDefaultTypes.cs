namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;

    public interface IHandleDefaultTypes
    {
        /// <summary>
        /// Registers default types at the given registry.
        /// </summary>
        /// <param name="typeRegistry">The type registry at which to register default types.</param>
        void Register(IRegisterTypes typeRegistry);

        /// <summary>
        /// Determines whether the handled type is applicable for the specific type.
        /// </summary>
        /// <param name="type">The which shall be checked.</param>
        /// <returns>True if the handled types are applicable for the specific type.</returns>
        bool IsApplicableFor(Type type);
    }
}