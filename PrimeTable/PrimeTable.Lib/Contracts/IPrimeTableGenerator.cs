﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTable.Lib.Contracts
{
    public interface IPrimeTableGenerator
    {
        int?[,] Generate(int length);
    }
}
