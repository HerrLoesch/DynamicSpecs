namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ConfigureTypeRegistration
{
    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_a_concrete_type_is_registered : SpecifiesStatically
    {
        [Test]
        public void Then_we_can_request_the_concrete_type()
        {
            var instance = this.GetInstance<IDummyInterface>();

            instance.Should().BeOfType<ConcreteClass>();
        }
    }
}