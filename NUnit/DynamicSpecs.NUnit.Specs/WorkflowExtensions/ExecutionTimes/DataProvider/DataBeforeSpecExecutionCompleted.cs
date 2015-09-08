
namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    public class DataBeforeSpecExecutionCompleted : IExtend<IRequestDataBeforeSpecExecutionCompleted>
    {
        public void Extend(IRequestDataBeforeSpecExecutionCompleted target)
        {
            target.Data = WorkflowExtensions.DataProvider.Data;
        }
    }
}
