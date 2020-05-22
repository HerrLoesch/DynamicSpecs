namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.FactorybasedRegistration
{
    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_based_on_a_factory_configuration : Specifies<object>, IRequestData
    {
        public int Data { get; set; }
        
        [Test]
        public void Then_the_data_is_provided()
        {
            this.Data.Should().Be(WorkflowExtensions.DataProvider.Data);
        }
    }
}