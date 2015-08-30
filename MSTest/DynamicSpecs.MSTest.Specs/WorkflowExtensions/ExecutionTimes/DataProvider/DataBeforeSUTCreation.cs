namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using DataProvider = DynamicSpecs.MSTest.Specs.WorkflowExtensions.DataProvider;

    public class DataBeforeSUTCreation : IExtend<IRequestDataBeforeSUTCreation>
    {
        public void Extend(IRequestDataBeforeSUTCreation target)
        {
            target.Data = DataProvider.Data;
        }
    }
}