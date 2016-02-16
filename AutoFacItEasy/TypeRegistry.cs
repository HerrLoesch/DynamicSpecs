namespace DynamicSpecs.AutoFacItEasy
{
    using System;

    using Autofac.Extras.FakeItEasy;
    using DynamicSpecs.Core;

    /// <summary>
    /// Container holding all registered types.
    /// </summary>
    public class TypeRegistry : IRegisterTypes, IResolveTypes
    {
        private readonly AutoFake fakeContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeRegistry"/> class.
        /// </summary>
        public TypeRegistry()
        {
            this.fakeContainer = new AutoFake();
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
        /// Registers a type as a target type.
        /// </summary>
        /// <typeparam name="TSource">Source type which is registered.</typeparam>
        /// <typeparam name="TTarget">Target type as which the source type is used.</typeparam>
        public void Register<TSource, TTarget>() where TSource : class, TTarget where TTarget : class
        {
            this.fakeContainer.Provide<TTarget, TSource>();
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
    }
}