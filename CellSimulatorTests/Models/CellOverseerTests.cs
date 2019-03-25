using Microsoft.VisualStudio.TestTools.UnitTesting;
using CellSimulator.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Interfaces;
using CellSimulator.Models;

namespace CellSimulator.Logic.Tests
{
    [TestClass]
    public class CellOverseerTests
    {
        [TestMethod]
        public void AddCellTest_SelfcreateCell()
        {
            CellOverseer overseer = new CellOverseer();
            Assert.IsTrue(overseer.CellList.Count == 0);
            overseer.AddCell();
            Assert.IsTrue(overseer.CellList.Count > 0);
        }

        [TestMethod]
        public void AddCellTest_CustomCell()
        {
            ICell cell = new Models.Cell();
            CellOverseer overseer = new CellOverseer();
            overseer.AddCell(cell);
            Assert.IsTrue(overseer.CellList.Contains(cell));
        }

        [TestMethod]
        public void SimulateNextTest()
        {
            const int TOTAL_RUNS = 1000;
            for (int i = 0; i < TOTAL_RUNS; ++i)
            {
                CellOverseer overseer = new CellOverseer();
                overseer.AddCell();
                overseer.SimulateNext();
            }
        }
    }
}