namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    public class DataByDefault : IExtend<IRequestDataByDefault>
    {
        public void Extend(IRequestDataByDefault target, WorkflowPosition workflowPosition)
        {
            target.Data = WorkflowExtensions.DataProvider.Data;
        }
    }
}
