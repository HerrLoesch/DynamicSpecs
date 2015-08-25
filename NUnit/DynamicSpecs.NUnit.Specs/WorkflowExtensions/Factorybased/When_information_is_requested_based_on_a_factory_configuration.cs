namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.Factorybased
{
    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_information_is_requested_based_on_a_factory_configuration : Specifies<object>, IRequestInformation
    {
        [Test]
        public void Then_additional_information_is_provided()
        {
            this.Information.ShouldBeEquivalentTo(42);
        }

        public int Information { get; set; }
    }
}