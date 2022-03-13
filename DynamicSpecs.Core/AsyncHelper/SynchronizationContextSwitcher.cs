using System;
using System.Threading;

namespace DynamicSpecs.Core.AsyncHelper
{
    //From AsyncCTP
    internal struct SynchronizationContextSwitcher : IDisposable
    {
        private SynchronizationContext originalSyncContext;

        public static SynchronizationContextSwitcher Capture()
        {
            // save the value to restore
            return new SynchronizationContextSwitcher { originalSyncContext = SynchronizationContext.Current };
        }

        public void Dispose()
        {
            // restore the sync context
            SynchronizationContext.SetSynchronizationContext(originalSyncContext);
        }
    }
}