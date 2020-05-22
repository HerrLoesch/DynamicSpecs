namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.TypebasedRegistration
{
    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_based_on_a_type_configuration : Specifies<object>, IRequestData
    {
        public int Data { get; set; }

        [Test]
        public void Then_the_information_is_provided()
        {
            this.Data.Should().Be(WorkflowExtensions.DataProvider.Data);
        }
    }
}