namespace DynamicSpecs.NUnit.Specs.WorkflowExtensions.ConfigureTypeRegistration
{
    using DynamicSpecs.Core;
    using DynamicSpecs.Core.WorkflowExtensions;

    public class TypeProvider : IExtend<ISpecify>
    {
        public void Extend(ISpecify target, WorkflowPosition currentPosition)
        {
            target.TypeRegistry.Register<ConcreteClass, IDummyInterface>();
        }
    }
}