using System;

namespace SharedClassLibrary
{
    public class Calculator : ICalculator
    {

        double ICalculator.Add(double firstNumber, double secondNumber)
        {
            try
            {
                return firstNumber + secondNumber;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void DoWok()
        {
            Console.WriteLine("hbjh");
        }
        double ICalculator.Divide(double firstNumber, double secondNumber)
        {
            try
            {
                return firstNumber / secondNumber;
            }
            catch (Exception)
            {

                throw;
            }
        }

        double ICalculator.Multiply(double firstNumber, double secondNumber)
        {
            try
            {

                return firstNumber * secondNumber;
            }
            catch (Exception)
            {

                throw;
            }
        }

        double ICalculator.Substract(double firstNumber, double secondNumber)
        {
            try
            {

                return firstNumber - secondNumber;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public interface ICalculator
    {
        public double Add(double firstNumber, double secondNumber);
        public double Substract(double firstNumber, double secondNumber);
        public double Multiply(double firstNumber, double secondNumber);
        public double Divide(double firstNumber, double secondNumber);

    }
}
