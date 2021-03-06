﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellSimulator.Interfaces
{
    public interface ICellPrinter
    {
        void PrintCells(IEnumerable<ICell> cellsToPrint);
        void PrintCellCount(IEnumerable<ICell> cellsToPrint);
    }
}
