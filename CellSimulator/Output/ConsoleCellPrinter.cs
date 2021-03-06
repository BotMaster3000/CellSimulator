﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Interfaces;

namespace CellSimulator.Output
{
    public class ConsoleCellPrinter : ICellPrinter
    {
        private const char VALUE_SEPARATION_VALUE = '|';

        public void PrintCellCount(IEnumerable<ICell> cellsToPrint)
        {
            Console.WriteLine($"Total Cells Alive: {cellsToPrint.Count()}");
            Console.WriteLine($"Oldest Cell: {cellsToPrint.Max(x => x.Age)}");
            Console.WriteLine($"Total Cells Born: {cellsToPrint.Count(x => x.LastAction == Enums.CellActionEnum.Born)}");
        }

        public void PrintCells(IEnumerable<ICell> cellsToPrint)
        {
            foreach (ICell cell in cellsToPrint)
            {
                Console.WriteLine(string.Join(VALUE_SEPARATION_VALUE.ToString(),
                    new string[] {
                    $"{nameof(cell.ID)}:{cell.ID}",
                    $"{nameof(cell.Age)}:{cell.Age}",
                    $"{nameof(cell.Food)}:{cell.Food}",
                    $"{nameof(cell.Energy)}:{cell.Energy}",
                    $"{nameof(cell.LastAction)}:{cell.LastAction}",
                    }));
            }
        }
    }
}
