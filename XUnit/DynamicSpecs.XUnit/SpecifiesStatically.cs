namespace DynamicSpecs.XUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    public class SpecifiesStatically : WorkflowSpecification
    {
        private SpecificationEngine engine;

        public SpecifiesStatically() : base(new TypeStoreFactory())
        {
            this.engine.Run();
            this.engine = new SpecificationEngine(this);
        }

        ~SpecifiesStatically()
        {
            this.engine.OnThenIsCompleted();

            this.engine.OnSpecExecutionCompleted();
        }
    }
}