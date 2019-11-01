using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBuilder
{
    public class Director
    {
        public void Construct(IBuilder IBuilder)
        {
            IBuilder.BuildPart1();
            IBuilder.BuildPart2();
            IBuilder.BuildPart3();
        }
    }
}
