using Microsoft.VisualStudio.TestTools.UnitTesting;
using CellSimulator.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Logic;
using CellSimulator.Interfaces;

namespace CellSimulator.Output.Tests
{
    [TestClass]
    public class ConsoleCellPrinterTests
    {
        [TestMethod]
        public void PrintCellsTest()
        {
            const int TOTAL_CELLS_TO_CREATE = 1000;
            ICellOverseer overseer = new Logic.CellOverseer();
            for (int i = 0; i < TOTAL_CELLS_TO_CREATE; ++i)
            {
                overseer.AddCell();
            }
            ConsoleCellPrinter printer = new ConsoleCellPrinter();
            printer.PrintCells(overseer.CellList);
        }
    }
}