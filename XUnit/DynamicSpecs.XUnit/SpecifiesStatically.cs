namespace DynamicSpecs.XUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    public class SpecifiesStatically : WorkflowSpecification
    {
        public SpecifiesStatically() : base(new TypeStoreFactory())
        {
            this.Engine.Run();
        }

        ~SpecifiesStatically()
        {
            this.Engine.OnThenIsCompleted();

            this.Engine.OnSpecExecutionCompleted();
        }
    }
}