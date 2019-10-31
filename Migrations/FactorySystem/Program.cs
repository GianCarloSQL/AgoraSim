using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Cartao Cartao;

            Cartao = Factory.GetCard((TipoCartao)1); // Sodexo
            Console.WriteLine(Cartao.ToString());
            Cartao = Factory.GetCard(TipoCartao.Visa); // 2
            Console.WriteLine(Cartao.ToString());
            Console.ReadKey();
        }
    }

}
