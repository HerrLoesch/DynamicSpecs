namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.TypeBased
{
    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_information_is_requested_based_on_a_type_configuration : Specifies<object>, IRequestInformation
    {
        [Test]
        public void Then_the_information_is_provided()
        {
            this.Information.ShouldBeEquivalentTo(42);
        }

        public int Information { get; set; }
    }
}