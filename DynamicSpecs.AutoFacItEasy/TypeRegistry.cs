namespace DynamicSpecs.AutoFacItEasy
{
    using System;
    using System.Collections.Generic;
    using Autofac;
    using DynamicSpecs.Core;
    /// <summary>
    /// Container holding all registered types.
    /// </summary>
    public class TypeRegistry : IRegisterTypes, IResolveTypes
    {
        private AutoFakeImpl fakeContainer;
        private bool disposedValue;
        private readonly Stack<ILifetimeScope> _scopes = new Stack<ILifetimeScope>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeRegistry"/> class.
        /// </summary>
        public TypeRegistry()
        {
            this.fakeContainer = new AutoFakeImpl(builder: new ContainerBuilder());
        }

        /// <summary>
        /// Registers an instance as a target type.
        /// </summary>
        /// <typeparam name="TSource">Source type which is registered.</typeparam>
        /// <typeparam name="TTarget">Target type as which the source type is used.</typeparam>
        /// <param name="source">Registered instance.</param>
        void IRegisterTypes.Register<TSource, TTarget>(TSource source)
        {
            this.fakeContainer.Provide((TTarget)(object)source);
        }

        /// <summary>
        /// Registers an instance as a target type.
        /// </summary>
        /// <typeparam name="TTarget">Target type as which the source type is used.</typeparam>
        /// <param name="source">Registered instance.</param>
        public void Register<TTarget>(TTarget source) where TTarget : class
        {
            this.fakeContainer.Provide(source);
        }

        /// <summary>
        /// Registers a type as a target type.
        /// </summary>
        /// <typeparam name="TSource">Source type which is registered.</typeparam>
        /// <typeparam name="TTarget">Target type as which the source type is used.</typeparam>
        public void Register<TSource, TTarget>() where TSource : class, TTarget where TTarget : class
        {
            this.fakeContainer.Provide<TTarget, TSource>();
        }

        /// <summary>
        /// Bulk Register of types.
        /// </summary>
        /// <typeparam name="TSource">Source type which is registered.</typeparam>
        /// <typeparam name="TTarget">Target type as which the source type is used.</typeparam>
        /// <typeparam name="Instance">Instance of the source that will be used as service.</typeparam>
        public void BatchRegister(List<(Type, Type, object)> RegisterTypes)
        {
            this.fakeContainer.BatchRegister(RegisterTypes);
        }

        /// <summary>
        /// Resolves an instance of the given type.
        /// </summary>
        /// <typeparam name="T">Type to resolve.</typeparam>
        /// <returns>Instance of type T</returns>
        public T Resolve<T>() where T : class
        {
            return this.fakeContainer.Resolve<T>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.fakeContainer?.Dispose();
                    this.fakeContainer = null;
                }
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~TypeRegistry()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}