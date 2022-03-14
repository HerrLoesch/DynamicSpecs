using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Autofac.Extras.FakeItEasy;

namespace DynamicSpecs.AutoFacItEasy
{
    /// <summary>
    /// Optimized implementation of AutoFake class that allows
    /// a batch registration of various types and instances
    /// with their corresponding order
    /// </summary>
    public class AutoFakeImpl : AutoFake
    {
        private bool _disposed;

        private readonly Stack<ILifetimeScope> _scopes = new Stack<ILifetimeScope>();

        private ILifetimeScope _currentScope;

        public AutoFakeImpl(bool strict = false, bool callsBaseMethods = false, Action<object> configureFake = null, ContainerBuilder builder = null, Action<ContainerBuilder> configureAction = null) 
            : base(strict, callsBaseMethods, configureFake, builder, configureAction)
        {
            base.Container.ChildLifetimeScopeBeginning += Container_ChildLifetimeScopeBeginning;
            _currentScope = base.Container.BeginLifetimeScope();
        }
        /// <summary>
        /// Resolve the specified type in the container (register it if needed).
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <param name="parameters">Optional parameters.</param>
        /// <returns>The service.</returns>
        new public T Resolve<T>(params Parameter[] parameters) => this._currentScope.Resolve<T>(parameters);

        /// <summary>
        /// Resolve the specified type in the container (register it if needed).
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The implementation of the service.</typeparam>
        /// <param name="parameters">Optional parameters.</param>
        /// <returns>The service.</returns>
        new public TService Provide<TService, TImplementation>(params Parameter[] parameters)
        {
            this._currentScope.BeginLifetimeScope(b =>
            {
                b.RegisterType<TImplementation>().As<TService>().InstancePerLifetimeScope();
            });

            return this._currentScope.Resolve<TService>(parameters);
        }

        /// <summary>
        /// Resolve the specified type in the container (register specified instance if needed).
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="instance">The instance to register if needed.</param>
        /// <returns>The instance resolved from container.</returns>
        new public TService Provide<TService>(TService instance)
            where TService : class
        {
            this._currentScope.BeginLifetimeScope(b =>
            {
                b.Register(c => instance).InstancePerLifetimeScope();
            });

            return this._currentScope.Resolve<TService>();
        }
        /// <summary>
        /// Bulk Register of types.
        /// </summary>
        /// <typeparam name="TSource">Source type which is registered.</typeparam>
        /// <typeparam name="TTarget">Target type as which the source type is used.</typeparam>
        /// <typeparam name="Instance">Instance of the source that will be used as service.</typeparam>
        public void BatchRegister(List<(Type, Type, object)> RegisterTypes)
        {
            this._currentScope.BeginLifetimeScope(b =>
            {
                foreach (var action in RegisterTypes)
                {
                    if (action.Item3 != default(object))
                        b.Register(c => action.Item3).As(action.Item1).InstancePerLifetimeScope();
                    else
                        b.RegisterType(action.Item1).As(action.Item2).InstancePerLifetimeScope();
                }
            });

            foreach (var action in RegisterTypes)
            {
                this._currentScope.Resolve(action.Item2);
            }
        }
        public void Container_ChildLifetimeScopeBeginning(object sender, Autofac.Core.Lifetime.LifetimeScopeBeginningEventArgs e)
        {
            this._currentScope = e.LifetimeScope;
            this._currentScope.ChildLifetimeScopeBeginning += Container_ChildLifetimeScopeBeginning;
            this._scopes.Push(this._currentScope);
        }

        /// <summary>
        /// Handles disposal of managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// <see langword="true" /> to dispose of managed resources (during a manual execution
        /// of <see cref="AutoFake.Dispose()"/>); or
        /// <see langword="false" /> if this is getting run as part of finalization where
        /// managed resources may have already been cleaned up.
        /// </param>
        new protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    while (this._scopes.Count > 0)
                        this._scopes.Pop().Dispose();

                    this.Container.Dispose();
                }
                this._disposed = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="AutoFakeImpl"/> class.
        /// </summary>
        [SecuritySafeCritical]
        ~AutoFakeImpl() => this.Dispose(false);
        /// <summary>
        /// Disposes internal container.
        /// </summary>
        [SecuritySafeCritical]
        new public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
