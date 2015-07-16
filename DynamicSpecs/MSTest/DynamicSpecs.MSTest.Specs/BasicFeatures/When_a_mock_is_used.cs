namespace DynamicSpecs.MSTest.Specs.BasicFeatures
{
    using DynamicSpecs.MSTest;
    using DynamicSpecs.MSTest.Specs.ExampleClasses;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class When_a_mock_is_used : Specifies<DummyClass>
    {
        [TestMethod]
        public void Then_the_mock_must_be_provided()
        {
            this.GetInstance<IAmAServiceDummy>().Should().NotBeNull();
        }

        [TestMethod]
        public void Then_each_call_for_a_mock_must_result_in_the_same_instance()
        {
            var firstInstance = this.GetInstance<IAmAServiceDummy>();
            var secondInstance = this.GetInstance<IAmAServiceDummy>();

            firstInstance.Should().BeSameAs(secondInstance);
        }
    }
}