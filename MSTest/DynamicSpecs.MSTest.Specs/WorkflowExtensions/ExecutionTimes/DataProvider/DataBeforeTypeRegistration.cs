namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using DataProvider = DynamicSpecs.MSTest.Specs.WorkflowExtensions.DataProvider;

    public class DataBeforeTypeRegistration : IExtend<IRequestDataBeforeTypeRegistration>
    {
        public void Extend(IRequestDataBeforeTypeRegistration target, WorkflowPosition workflowPosition)
        {
            target.Data = DataProvider.Data;
        }
    }
}