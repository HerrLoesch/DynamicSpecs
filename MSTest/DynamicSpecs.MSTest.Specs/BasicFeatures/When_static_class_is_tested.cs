namespace DynamicSpecs.MSTest.Specs.BasicFeatures
{
    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class When_static_class_is_tested : SpecifiesStatically
    {
        public override void Given()
        {
            StaticDummy.Data = 5;
        }

        public override void When()
        {
        }

        [TestMethod]
        public void Then_no_type_is_needed_for_specs()
        {
            StaticDummy.Data.Should().Be(5);
        }
    }

    public static class StaticDummy
    {
        public static int Data { get; set; }
    }
}