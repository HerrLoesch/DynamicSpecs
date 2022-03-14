namespace DynamicSpecs.Core.WorkflowExtensions
{
    /// <summary>
    /// Interface which must be implemented to enrich the execution of the given type with additional worksteps.
    /// </summary>
    /// <typeparam name="TToExtend">Type to extend</typeparam>
    public interface IExtend<TToExtend>
    {
        /// <summary>
        /// Extends the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="currentPosition">The current position.</param>
        void Extend(TToExtend target, WorkflowPosition currentPosition);
    }

    /// <summary>
    /// This type is used to manage all extension independent from the type they extend.
    /// </summary>
    internal interface IExtend
    {
        /// <summary>
        /// Gets the step of the execution workflow of a specification at which the extension needs to be applied.
        /// </summary>
        WorkflowPosition WorkflowPosition { get; }

        /// <summary>
        /// Executes the code which actually extends the specified target.
        /// </summary>
        /// <param name="target">The target to extend.</param>
        /// <param name="workflowPosition">The workflow position.</param>
        void Extend(object target, WorkflowPosition workflowPosition);
    }
}