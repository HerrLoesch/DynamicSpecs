namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.DataProvider
{
    using DynamicSpecs.Core.WorkflowExtensions;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    public class StatelessMultipleDataProvider : IExtend<IRequestStatelessData>
    {
        public static int GivenData = 42;

        public static int WhenData = 24;


        public void Extend(IRequestStatelessData target, WorkflowPosition currentPosition)
        {
            if (currentPosition == WorkflowPosition.Given)
            {
                target.GivenData = GivenData;
            }
            else if (currentPosition == WorkflowPosition.When)
            {
                target.WhenData = WhenData;
            }
        }
    }
}