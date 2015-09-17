namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;

    public class MultipleDataProvider : IExtend<IRequestDataMultipleTimes>
    {
        private int data = 1;

        public void Extend(IRequestDataMultipleTimes target)
        {
            target.Data = this.data;
            this.data++;
        }
    }
}