namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ExecutionTimes
{
    using DynamicSpecs.Core;

    /// <summary>
    /// </summary>
    public class ExtensionSpecsBaseStructure : Specifies<object>
    {
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
    }
}