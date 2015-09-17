namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using DataProvider = DynamicSpecs.NUnit.Specs.WorkflowExtensions.DataProvider;

    public class DataBeforeTypeRegistration : IExtend<IRequestDataBeforeTypeRegistration>
    {
        public void Extend(IRequestDataBeforeTypeRegistration target, WorkflowPosition workflowPosition)
        {
            target.Data = DataProvider.Data;
        }
    }
}