namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;

    /// <summary>
    /// Steps taken during the execution of a specification for which an extension can be registered.
    /// </summary>
    [Flags]
    public enum WorkflowPosition
    {
        /// <summary>
        /// Default step.
        /// </summary>
        Default =  0,

        /// <summary>
        /// After the type registry is created but before the first type is registered.
        /// </summary>
        TypeRegistration = 2,

        /// <summary>
        /// After alls types are registered but before the SUT is created.
        /// </summary>
        SUTCreation = 4, 

        /// <summary>
        /// After the SUT is created but before the given phase.
        /// </summary>
        Given = 8, 

        /// <summary>
        /// After the given but before the when phase.
        /// </summary>
        When = 16,

        /// <summary>
        /// Executed at the end of one then Step.
        /// </summary>
        Then = 32,

        /// <summary>
        /// Last step during the run of a particular spec.
        /// </summary>
        SpecExecutionCompleted = 64
    }
}