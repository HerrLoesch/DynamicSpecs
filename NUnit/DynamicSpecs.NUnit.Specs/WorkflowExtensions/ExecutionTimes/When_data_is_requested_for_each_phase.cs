namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.Core;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_for_each_phase : Specifies<object>, IRequestDataBeforeTypeRegistration
    {
        protected override void RegisterTypes(IRegisterTypes typeRegistration)
        {
            this.DataOfRegisterTypes = this.Data;
            base.RegisterTypes(typeRegistration);
        }

        public int DataOfRegisterTypes { get; set; }

        public int Data { get; set; }

        [Test]
        public void Then_data_is_available_during_type_registration()
        {
            this.DataOfRegisterTypes.ShouldBeEquivalentTo(WorkflowExtensions.DataProvider.Data);
        }
    }
}