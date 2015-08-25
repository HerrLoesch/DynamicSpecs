namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;

    public class ExtensionPoint<TTargetType> : IExtend where TTargetType : class 
    {
        public ExtensionPoint()
        {
            this.TargetType = typeof(TTargetType);
        }

        public Type TargetType { get; set; }

        public void With<TExtensionType>(Func<TExtensionType> factory) where TExtensionType : IExtend<TTargetType>
        {
            this.Extension = factory.Invoke();
        }

        public IExtend<TTargetType> Extension { get; set; }

        public void Extend(TTargetType target)
        {
            this.Extension.Extend(target);
        }

        public void Extend(object target)
        {
            this.Extend(target as TTargetType);
        }
    }
}
