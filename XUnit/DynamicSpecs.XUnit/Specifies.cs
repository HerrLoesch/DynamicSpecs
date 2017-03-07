namespace DynamicSpecs.XUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;


    public class Specifies<T> : TypedWorkflowSpecification<T> where T : class
    {
        public Specifies() : base(new TypeStoreFactory())
        {
            this.Engine.Run();
        }

        ~Specifies()
        {
            this.Engine.OnThenIsCompleted();
            this.Engine.OnSpecExecutionCompleted();
        }
    }
}
