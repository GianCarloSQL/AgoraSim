using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBuilder
{
    class Program
    {
        static void Main(string[] args)
        {

            T t = new T();
            foreach (var item in typeof(T).GetType().GetProperties())
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();

        }
    }

    class T
    {
        public int MyProperty { get; set; }
        public List<T> Lista { get; set; }
    }
}
