using System;
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

        public void PrintCells(IEnumerable<ICell> cellsToPrint)
        {
            foreach (ICell cell in cellsToPrint)
            {
                Console.WriteLine(string.Join(VALUE_SEPARATION_VALUE.ToString(),
                    new string[] {
                    $"{nameof(cell.ID)}:{cell.ID}" +
                    $"{nameof(cell.Age)}:{cell.Age}" +
                    $"{nameof(cell.Food)}:{cell.Food}" +
                    $"{nameof(cell.Energy)}:{cell.Energy}" +
                    $"{nameof(cell.LastAction)}:{cell.LastAction}"
                    }));
            }
        }
    }
}
