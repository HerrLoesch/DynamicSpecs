namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.TypebasedRegistration
{
    using FluentAssertions;

    using global::NUnit.Framework;

    public class WhenDataIsRequestedBasedOnATypeConfiguration : Specifies<object>, IRequestData
    {
        [Test]
        public void Then_the_information_is_provided()
        {
            this.Data.ShouldBeEquivalentTo(42);
        }

        public int Data { get; set; }
    }
}