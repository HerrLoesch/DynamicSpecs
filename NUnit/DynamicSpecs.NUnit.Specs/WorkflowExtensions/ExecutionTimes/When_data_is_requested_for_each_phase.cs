namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.Core;
    using DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes.Interfaces;

    using FluentAssertions;

    using global::NUnit.Framework;

    public class When_data_is_requested_for_each_phase : Specifies<object>, IRequestDataBeforeTypeRegistration, IRequestDataBeforeGiven, IRequestDataBeforeWhen
    {
        #region infrastructure

        /// <summary>
        /// Creates the system Under Test and resolves all it's dependencies.
        /// </summary>
        /// <returns>Instance of the SUT.</returns>
        protected override object CreateSut()
        {
            this.DataOfCreatSut = this.Data;
            return base.CreateSut();
        }

        /// <summary>
        /// Registers all types needed by the SUT at a central registration or container.
        /// </summary>
        /// <param name="typeRegistration">
        /// Instance which shall contain the registered types.
        /// </param>
        protected override void RegisterTypes(IRegisterTypes typeRegistration)
        {
            this.DataOfRegisterTypes = this.Data;
            base.RegisterTypes(typeRegistration);
        }

        /// <summary>
        /// </summary>
        public int DataOfRegisterTypes { get; set; }

        /// <summary>
        /// </summary>
        public int DataOfCreatSut { get; set; }

        public int Data { get; set; }

        /// <summary>
        /// Method containing all code needed during the when phase.
        /// </summary>
        public override void When()
        {
            this.DataOfWhen = this.Data;
        }

        /// <summary>
        /// Method containing all code needed during the given phase.
        /// </summary>
        public override void Given()
        {
            this.DataOfGiven = this.Data;
        }

        /// <summary>
        /// </summary>
        public int DataOfGiven { get; set; }

        /// <summary>
        /// </summary>
        public int DataOfWhen { get; set; }

        #endregion
        
        [Test]
        public void Then_data_is_available_during_type_registration()
        {
            this.DataOfRegisterTypes.ShouldBeEquivalentTo(WorkflowExtensions.DataProvider.Data);
        }

        [Test]
        public void Then_data_is_available_during_given_phase()
        {
            this.DataOfRegisterTypes.ShouldBeEquivalentTo(WorkflowExtensions.DataProvider.Data);
        }

        [Test]
        public void Then_data_is_available_during_when_phase()
        {
            this.DataOfWhen.ShouldBeEquivalentTo(WorkflowExtensions.DataProvider.Data);
        }
    }
}