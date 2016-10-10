namespace DynamicSpecs.NUnit.Specs.BasicFeatures
{
    using DynamicSpecs.NUnit;

    using FluentAssertions;

    using global::NUnit.Framework;


    public class When_static_class_is_tested : SpecifiesStatically
    {
        public override void Given()
        {
            StaticDummy.Data = 5;
        }

        public override void When()
        {
            
        }

        [Test]
        public void Then_no_type_is_needed_for_specs()
        {
            StaticDummy.Data.ShouldBeEquivalentTo(5);
        }

    }

    public static class StaticDummy
    {
        public static int Data { get; set; }
    }
}
