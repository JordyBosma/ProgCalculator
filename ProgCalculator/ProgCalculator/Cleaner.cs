using System;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace ProgCalculator
{
    class Cleaner : IDisposable
    {
        bool disposed = false; //Is Dispose called?
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true); //SafeHandle instance

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) { return; }
            if (disposing) { handle.Dispose(); }

            disposed = true;
        }
    }
}
