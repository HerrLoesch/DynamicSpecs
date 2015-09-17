namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using DataProvider = DynamicSpecs.NUnit.Specs.WorkflowExtensions.DataProvider;

    public class DataBeforeGiven : IExtend<IRequestDataBeforeGiven>
    {
        public void Extend(IRequestDataBeforeGiven target, WorkflowPosition workflowPosition)
        {
            target.Data = DataProvider.Data;
        }
    }
}