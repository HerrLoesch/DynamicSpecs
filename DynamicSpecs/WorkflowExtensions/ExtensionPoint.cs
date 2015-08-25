namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;
    using System.Linq;
    using System.Reflection;

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

        public void With<TExtensionType>() where TExtensionType : class
        {
            var type = typeof(TExtensionType);
            var defaultConstructor = type.GetConstructors().FirstOrDefault(x => x.GetParameters().Length == 0);

            if (defaultConstructor == null)
            {
                throw new InvalidOperationException("No default constructor found. Extensions need default constructors or must be registered with a factory.");
            }

            this.Extension = defaultConstructor.Invoke(new object[0]) as IExtend<TTargetType>;
        }
    }
}
