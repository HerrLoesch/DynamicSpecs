namespace DynamicSpecs.NUnit.Specs.BasicFeatures
{
    using DynamicSpecs.NUnit;
    using DynamicSpecs.NUnit.Specs.ExampleClasses;

    using FluentAssertions;

    using global::NUnit.Framework;


    public class When_support_class_with_parameters_is_used_during_when_phase : Specifies<DataContainer>
    {

        public override void When()
        {
            this.When<Set_data_for_container, int>(42);
        }

        [Test]
        public void Then_the_data_is_available_for_the_support_class()
        {
            this.SUT.Data.ShouldBeEquivalentTo(42);
        }
    }
}
