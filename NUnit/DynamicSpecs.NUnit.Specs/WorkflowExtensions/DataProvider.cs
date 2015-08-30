namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions
{
    public class DataProvider : IProvideData
    {
        public void Extend(IRequestData target)
        {
            target.Data = 42;
        }
    }
}