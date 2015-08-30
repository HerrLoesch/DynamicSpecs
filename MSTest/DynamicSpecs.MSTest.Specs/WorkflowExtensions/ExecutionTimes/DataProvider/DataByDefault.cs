namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    public class DataByDefault : IExtend<IRequestDataByDefault>
    {
        public void Extend(IRequestDataByDefault target)
        {
            target.Data = WorkflowExtensions.DataProvider.Data;
        }
    }
}
