using System;

namespace ConsoleNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o numero");
            var n =  Console.ReadLine();
            int n1 = 0;
            int.TryParse(n,out n1);
            Calcula();
        }

        private static void Calcula()
        {
           
        }
    }
}
