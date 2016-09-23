namespace DynamicSpecs.Core
{
    /// <summary>
    /// Base class of all specifications, handling the basic workflow.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the system under test.
    /// </typeparam>
    public abstract class TypedWorkflowSpecification<T> : WorkflowSpecification, ISpecify<T> where T : class
    {
        /// <summary>
        /// Gets or sets an Instance of the SUT.
        /// </summary>
        public T SUT { get; protected set; }

        /// <summary>
        /// Creates the system Under Test and resolves all it's dependencies.
        /// </summary>
        /// <returns>Instance of the SUT.</returns>
        protected virtual T CreateSut()
        {
            return this.TypeResolver.Resolve<T>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TypedWorkflowSpecification{T}"/> class.
        /// </summary>
        public TypedWorkflowSpecification()
        {
            this.WorkflowExtension = this.SetSut;
        }

        /// <summary>
        /// Sets the system under Test.
        /// </summary>
        private void SetSut()
        {
            this.SUT = this.CreateSut();
        }
    }
}