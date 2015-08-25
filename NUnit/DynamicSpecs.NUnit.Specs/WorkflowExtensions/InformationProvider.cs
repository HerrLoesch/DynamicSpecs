namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions
{
    public class InformationProvider : IProvideInformation
    {
        public void Extend(IRequestInformation target)
        {
            target.Information = 42;
        }
    }
}