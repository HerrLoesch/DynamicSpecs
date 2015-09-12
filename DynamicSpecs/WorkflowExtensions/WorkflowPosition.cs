namespace DynamicSpecs.Core.WorkflowExtensions
{
    /// <summary>
    /// Steps taken during the execution of a specification for which an extension can be registered.
    /// </summary>
    public enum WorkflowPosition
    {
        /// <summary>
        /// Default step.
        /// </summary>
        Default,

        /// <summary>
        /// After the type registry is created but before the first type is registered.
        /// </summary>
        TypeRegistration,

        /// <summary>
        /// After alls types are registered but before the SUT is created.
        /// </summary>
        SUTCreation, 

        /// <summary>
        /// After the SUT is created but before the given phase.
        /// </summary>
        Given, 

        /// <summary>
        /// After the given but before the when phase.
        /// </summary>
        When,

        /// <summary>
        /// Executed after at the end of one then Step.
        /// </summary>
        Then,

        /// <summary>
        /// Last step during the run of a particular spec.
        /// </summary>
        SpecExecutionCompleted
    }
}