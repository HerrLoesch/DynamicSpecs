namespace DynamicSpecs.XUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;


    public class Specifies<T> : TypedWorkflowSpecification<T> where T : class
    {
        private SpecificationEngine engine;

        public Specifies() : base(new TypeStoreFactory())
        {
            this.engine = new SpecificationEngine(this);
            this.engine.Run();
        }

        ~Specifies()
        {
            this.engine.OnThenIsCompleted();
            this.engine.OnSpecExecutionCompleted();
        }
    }
}
