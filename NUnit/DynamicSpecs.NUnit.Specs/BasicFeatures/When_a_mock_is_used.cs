namespace DynamicSpecs.NUnit.Specs.BasicFeatures
{
    using DynamicSpecs.NUnit.Specs.ExampleClasses;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_a_mock_is_used : Specifies<DummyClass>
    {
        [Test]
        public void Then_the_mock_must_be_provided()
        {
            this.GetInstance<IAmAServiceDummy>().Should().NotBeNull();
        }

        [Test]
        public void Then_each_call_for_a_mock_must_result_in_the_same_instance()
        {
            var firstInstance = this.GetInstance<IAmAServiceDummy>();
            var secondInstance = this.GetInstance<IAmAServiceDummy>();

            firstInstance.Should().BeSameAs(secondInstance);
        }
    }
}