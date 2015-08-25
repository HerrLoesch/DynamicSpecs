namespace DynamicSpecs.Core.WorkflowExtensions
{
    using System;
    using System.Collections.Generic;

    public class Extensions
    {
        protected ExtensionPoint<T> Extend<T>() where T : class 
        {
            var extensionPoint = new ExtensionPoint<T>();
            this.Add(typeof(T), extensionPoint);
            return extensionPoint;
        }

        private void Add(Type type, IExtend extension)
        {
            if (!extensions.ContainsKey(type))
            {
                extensions.Add(type, new List<IExtend>());
            }

            extensions[type].Add(extension);
        }

        internal static bool TryGetValue(Type key, out List<IExtend> value)
        {
            return extensions.TryGetValue(key, out value);
        }

        private static Dictionary<Type, List<IExtend>> extensions = new Dictionary<Type, List<IExtend>>();
    }
}