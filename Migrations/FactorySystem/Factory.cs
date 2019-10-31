using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystem
{
    public static class Factory
    {
        public static Cartao GetCard(TipoCartao Tipo)
        {
            switch (Tipo)
            {
                case TipoCartao.Sodexo:
                    return new CartaoSodexo();
                case TipoCartao.Visa:
                    return new CartaoVisa();
            }
            return null;
        }
    }
}
