
namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    public class DataBeforeThenIsCompleted : IExtend<IRequestDataBeforeThenIsCompleted>
    {
        public void Extend(IRequestDataBeforeThenIsCompleted target)
        {
            target.Data = WorkflowExtensions.DataProvider.Data;
        }
    }
}
