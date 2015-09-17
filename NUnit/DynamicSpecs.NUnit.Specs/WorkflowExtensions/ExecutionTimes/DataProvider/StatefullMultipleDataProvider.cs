namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;

    public class StatefullMultipleDataProvider : IExtend<IRequestStatefullData>
    {
        private int data = 1;

        public void Extend(IRequestStatefullData target, WorkflowPosition workflowPosition)
        {
            target.Data = this.data;
            this.data++;
        }
    }
}