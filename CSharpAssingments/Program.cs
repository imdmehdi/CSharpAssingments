using System;
using System.Collections.Generic;
using System.Data;

namespace CSharpAssingments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            (string Name, int Age, string Subject) data = (Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Console.ReadLine());

            var returnfromMethod=CreateDataSet(data);
            Console.WriteLine("Printing result returned from method.");
            returnfromMethod.ForEach(x => Console.WriteLine(x.Item1+ " "+ x.Item2+" "+x.Item3));
            Console.ReadLine();
        }
        public static List<Tuple<string, int, string>> CreateDataSet( (string Name, int Age, string Subject )input)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("Subject", typeof(string));

            for (int i =0; i <5; i++)
            {
                var row = table.NewRow();
                row[0] = input.Name+ "Its manipulated";
                row[1] = input.Age;
                row[2] = input.Subject;
                table.Rows.Add(row);
            }

            List<Tuple<string, int, string>> listTup = new List<Tuple<string, int, string>>();

            foreach (DataRow r in table.Rows)
            {
                var tupObj = Tuple.Create((string)r[0], (int)r[1], (string)r[2]);
                listTup.Add(tupObj);
            }

            Console.WriteLine("Printing manipulated result inside of method.");
            listTup.ForEach(x => Console.WriteLine(x.Item1 + " " + x.Item2 + " "+x.Item3));


            return listTup ;
        }
    }
}
