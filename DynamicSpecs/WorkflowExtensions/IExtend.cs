namespace DynamicSpecs.Core.WorkflowExtensions
{
    public interface IExtend<T>
    {
        void Extend(T target);
    }

    internal interface IExtend
    {
        void Extend(object target);

        /// <summary>
        /// </summary>
        WorkflowSteps WorkflowPosition { get; }
    }
}