namespace DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.MSTest.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class When_data_is_requested_before_SUT_creation : Specifies<object>, IRequestDataBeforeSUTCreation
    {
        public int Data { get; set; }

        protected override object CreateSut()
        {
            this.DataOfCreatSut = this.Data;
            return base.CreateSut();
        }

        public int DataOfCreatSut { get; set; }

        [TestMethod]
        public void Then_data_is_available()
        {
            this.DataOfCreatSut.ShouldBeEquivalentTo(WorkflowExtensions.DataProvider.Data);
        }
    }
}