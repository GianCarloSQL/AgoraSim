﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBuilder
{
    public interface IBuilder
    {
        void BuildPart1();
        void BuildPart2();
        void BuildPart3();
        Product GetProduct();
    }
}
