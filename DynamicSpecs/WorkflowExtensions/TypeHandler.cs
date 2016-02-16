namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;

    public class TypeHandler<TSource, TTarget> : IHandleTypes
        where TTarget : class
        where TSource : class, TTarget
    {
        private Type MappingTargetType { get; set; }

        private Type MappingSourceType { get; set; }

        private Type TargetType { get; set; }

        public TypeHandler()
        {
            this.MappingTargetType = typeof(TTarget);
            this.MappingSourceType = typeof(TSource);
        }

        public void Register(IRegisterTypes typeRegistry)
        {
            typeRegistry.Register<TSource, TTarget>();
        }

        public void For<T>()
        {
            this.TargetType = typeof(T);
        }

        public bool IsApplicableFor(Type type)
        {
            return type == this.TargetType;
        }
    }
}