namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions
{
    public class DataProvider : IProvideData
    {
        public static readonly int Data = 42;

        public void Extend(IRequestData target)
        {
            target.Data = Data;
        }
    }
}