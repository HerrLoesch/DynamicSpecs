namespace DynamicSpecs.NUnit.Specs.BasicFeatures
{
    using DynamicSpecs.Core;
    using DynamicSpecs.NUnit.Specs.ExampleClasses;

    public class Set_data_for_container : ISupport<int>
    {
        public void Support(ISpecify specification, int data)
        {
            specification.GetInstance<DataContainer>().Data = data;
        }
    }
}