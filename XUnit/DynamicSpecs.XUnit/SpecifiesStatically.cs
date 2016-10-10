namespace DynamicSpecs.XUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    public class SpecifiesStatically : WorkflowSpecification
    {
        /// <summary>
        /// Gets or sets a container holding all registered types and can resolve mocks if no registration was made for a type.
        /// </summary>
        public TypeRegistry Registry { get; private set; }

        public SpecifiesStatically()
        {
            this.Registry = new TypeRegistry();
            this.Run();
        }

        protected override IRegisterTypes GetTypeRegistry()
        {
            return this.Registry;
        }

        protected override IResolveTypes GetTypeResolver()
        {
            return this.Registry;
        }

        ~SpecifiesStatically()
        {
            this.OnThenIsCompleted();

            this.OnSpecExecutionCompleted();
        }
    }
}