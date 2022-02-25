using System;
using System.ComponentModel;
using System.Diagnostics;

namespace MemoryManagementAssingment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            #region code related to memory management assingment 1.
            {

                Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
                Program p = new Program();
                p.MakeObject();
                Console.WriteLine("Generation: {0}", GC.GetGeneration(p));

                Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

                GC.Collect(0);

                Console.WriteLine("Generation: {0}", GC.GetGeneration(p));

                Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

                p.MakeObject();

                Console.WriteLine("Generation: {0}", GC.GetGeneration(p));

                Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
               GC.Collect(2);

                Console.WriteLine("Generation: {0}", GC.GetGeneration(p));
                Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            }
            #endregion


            #region code related to assingment 2
            {
                IntPtr hwnd = new IntPtr(3);
                UnManagedWork unManagedWork = new UnManagedWork(Process.GetCurrentProcess().MainWindowHandle);
                unManagedWork.Dispose();
            }

            #endregion
            Console.ReadLine();
        }
        void MakeObject()
        {
            DbConnection obj;
            for (int i = 0; i < 10; i++)
            {
                 obj = new DbConnection("raju");

            }
        }

    }

    public class DbConnection
    {
        public string name= null;
        public DbConnection(string name)
        {
            this.name = name;
        }
        ~DbConnection(){
            Console.WriteLine("Class DbConnection destructor called.");
        }
       


    }

    public class UnManagedWork : IDisposable
    {
        private IntPtr handle;
        private Component component = new Component();
        private bool isDisposed = false;

        
        public UnManagedWork(IntPtr handle)
        {
            this.handle = handle;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    component.Dispose();
                }

                CloseHandle(handle);
                handle = IntPtr.Zero;

                isDisposed = true;
            }
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        ~UnManagedWork()
        {
            Dispose(disposing: false);
        }
    }
    
}
