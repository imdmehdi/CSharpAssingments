using System;
using System.Threading;
using System.Threading.Tasks;

namespace Topic8Assingment
{
    internal class Assingmnt1
    {
        #region assingment
        static void Main(string[] args)
        { 

            int count = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i+1);count++;//main thread
                if (count == 2)
                {
                    count=0;
                    Thread.Sleep(5000);
                }
            }
            Task.Factory.StartNew(() => {
                int count = 0;

                for (int i = 100; i < 110; i++)
                {
                    Console.WriteLine(i + 1); count++;//child thread
                    if (count == 2)
                    {
                        count = 0;
                        Thread.Sleep(3000);
                    }
                }
            });
            Console.ReadLine();
        }
        #endregion

    }

    internal class Assingmnt2
    {
        #region assingment
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Name of current thead={1}:   {0}",i + 1, Thread.CurrentThread.Name); //main thread
                
            }
            Task.Factory.StartNew(() => {
                Thread.CurrentThread.Name = "Child";

                for (int i = 64; i <= 73; i++)
                {
                    Console.WriteLine("Name of current thead={0}   {1}" , Thread.CurrentThread.Name ,Convert.ToChar(i + 1)); //chid thread
                   
                }
            });
            Console.ReadLine();
        }
        #endregion

    }

    internal class Assingmnt3
    {
        #region assingment
        static  void  Main(string[] args)
        {
            Assingmnt3 assingmnt3=  new Assingmnt3();
            Thread.CurrentThread.Name = "Main";
            
            var t1 = new Task(() => assingmnt3.DoWork("One"));
            var t2 = new Task(() => assingmnt3.DoWork("Two"));
            var t3 = new Task(() => assingmnt3.DoWork("Three"));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Wait();
            t2.Wait();
            t3.Wait();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i + 1); //main thread

            }
            Console.ReadLine();
        }
        void DoWork(string childName)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i + 1 + "   " + childName); //child thread

            }
        }
        #endregion

    }
}
