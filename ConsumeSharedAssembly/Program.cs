extern alias newV;
extern alias oldV;
using oldV::SharedClassLibrary;
using newV::SharedClassLibrary;

using System;

namespace ConsumeSharedAssembly
{
    internal class Program
    {
        //used gacutil.exe -i SharedClassLibrary.dll for installatin in gac. Manual change of version  before build.
        static void Main(string[] args)
        {
            oldV.SharedClassLibrary.ICalculator calculator = new oldV.SharedClassLibrary.Calculator();
            newV.SharedClassLibrary.ICalculator calculatorNew = new newV.SharedClassLibrary.Calculator();


            Console.WriteLine("Enter the action to be performed");
            Console.WriteLine("Press 1 for Addition");
            Console.WriteLine("Press 2 for Subtraction");
            Console.WriteLine("Press 3 for Multiplication");
            Console.WriteLine("Press 4 for Division \n");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 1st input");
            double input_1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter 2nd input");
            double input_2 = Convert.ToDouble(Console.ReadLine());
            double result = 0;
            switch (action)
            {
                case 1:
                    {
                        result = calculator.Add(input_1, input_2);
                        break;
                    }
                case 2:
                    {
                        result = calculator.Substract(input_1, input_2);
                        break;
                    }
                case 3:
                    {
                       result = calculatorNew.Multiply(input_1, input_2);
                        break;
                    }
                case 4:
                    {
                        //result = calculator.Divide(input_1, input_2);
                        break;
                    }
                default:
                    Console.WriteLine("Wrong action!! try again");
                    break;
            }
            Console.WriteLine("The result is {0}", result);
            Console.ReadKey();

        }
    }
}
