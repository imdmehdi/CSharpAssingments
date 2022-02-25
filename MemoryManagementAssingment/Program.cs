using System;

namespace MemoryManagementAssingment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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

}
