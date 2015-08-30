namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_before_SUT_creation : Specifies<object>, IRequestDataBeforeSUTCreation
    {
        public int Data { get; set; }

        /// <summary>
        /// Creates the system Under Test and resolves all it's dependencies.
        /// </summary>
        /// <returns>Instance of the SUT.</returns>
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