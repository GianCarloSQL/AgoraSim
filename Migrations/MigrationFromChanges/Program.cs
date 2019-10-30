using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationFromChanges
{
    class Program
    {
        static ContextSystem Context = new ContextSystem();
        static void Main(string[] args)
        {
               
            Context.Usuarios.ToList().ForEach(u => Console.WriteLine(u.Nome));
            Console.ReadKey();
        }   
    }
}
