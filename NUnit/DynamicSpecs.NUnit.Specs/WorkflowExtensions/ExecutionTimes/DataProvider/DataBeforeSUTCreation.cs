namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using DataProvider = DynamicSpecs.NUnit.Specs.WorkflowExtensions.DataProvider;

    public class DataBeforeSUTCreation : IExtend<IRequestDataBeforeSUTCreation>
    {
        public void Extend(IRequestDataBeforeSUTCreation target)
        {
            target.Data = DataProvider.Data;
        }
    }
}