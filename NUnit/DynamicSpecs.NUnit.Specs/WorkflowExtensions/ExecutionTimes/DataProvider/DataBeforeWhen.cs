namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using DataProvider = DynamicSpecs.NUnit.Specs.WorkflowExtensions.DataProvider;

    public class DataBeforeWhen : IExtend<IRequestDataBeforeWhen>
    {
        public void Extend(IRequestDataBeforeWhen target)
        {
            target.Data = DataProvider.Data;
        }
    }
}