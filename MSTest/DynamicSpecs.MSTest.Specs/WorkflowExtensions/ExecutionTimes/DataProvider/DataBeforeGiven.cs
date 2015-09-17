namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using DataProvider = DynamicSpecs.MSTest.Specs.WorkflowExtensions.DataProvider;

    public class DataBeforeGiven : IExtend<IRequestDataBeforeGiven>
    {
        public void Extend(IRequestDataBeforeGiven target, WorkflowPosition workflowPosition)
        {
            target.Data = DataProvider.Data;
        }
    }
}