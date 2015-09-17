namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions
{
    using DynamicSpecs.Core.WorkflowExtensions;

    public class DataProvider : IProvideData
    {
        public static readonly int Data = 42;

        public void Extend(IRequestData target, WorkflowPosition workflowPosition)
        {
            target.Data = Data;
        }
    }
}