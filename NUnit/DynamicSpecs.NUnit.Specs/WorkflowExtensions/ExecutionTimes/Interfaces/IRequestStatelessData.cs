namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces
{
    public interface IRequestStatelessData
    {
        int GivenData { get; set; }

        int WhenData { get; set; }
    }
}