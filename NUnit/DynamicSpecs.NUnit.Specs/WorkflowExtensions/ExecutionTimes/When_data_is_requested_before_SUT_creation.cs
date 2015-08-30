namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_before_SUT_creation : Specifies<object>, IRequestDataBeforeSUTCreation
    {
        public int Data { get; set; }

        protected override object CreateSut()
        {
            this.DataOfCreatSut = this.Data;
            return base.CreateSut();
        }

        public int DataOfCreatSut { get; set; }

        [Test]
        public void Then_data_is_available()
        {
            this.DataOfCreatSut.ShouldBeEquivalentTo(WorkflowExtensions.DataProvider.Data);
        }
    }
}