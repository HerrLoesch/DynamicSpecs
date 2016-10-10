namespace DynamicSpecs.XUnit.Specs
{
    using DynamicSpecs.XUnit.Specs.ExampleClasses;

    using FluentAssertions;

    using Xunit;

    public class When_a_mock_is_used : Specifies<DummyClass>
    {
        [Fact]
        public void Then_the_mock_must_be_provided()
        {
            this.GetInstance<IAmAServiceDummy>().Should().NotBeNull();
        }

        [Fact]
        public void Then_each_call_for_a_mock_must_result_in_the_same_instance()
        {
            var firstInstance = this.GetInstance<IAmAServiceDummy>();
            var secondInstance = this.GetInstance<IAmAServiceDummy>();

            firstInstance.Should().BeSameAs(secondInstance);
        }
    }
}