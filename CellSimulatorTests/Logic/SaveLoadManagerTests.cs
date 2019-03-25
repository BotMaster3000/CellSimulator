using Microsoft.VisualStudio.TestTools.UnitTesting;
using CellSimulator.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Interfaces;
using System.IO;

namespace CellSimulator.Logic.Tests
{
    [TestClass]
    public class SaveLoadManagerTests
    {
        const string TESTFILE = "cellListTemp.txt";

        private void CreateTestFile(int numberOfTestCells)
        {
            SaveLoadManager manager = new SaveLoadManager();
            CellOverseer overseer = new CellOverseer();
            for (int i = 0; i < numberOfTestCells; ++i)
            {
                overseer.AddCell();
            }
            manager.SaveToFile(TESTFILE, overseer.CellList);
        }

        private void DeleteTestFile()
        {
            File.Delete(TESTFILE);
        }

        [TestMethod]
        public void LoadFromFileTest_ValidFile_ShouldReturnICellList()
        {
            const int NUMBER_OF_TEST_CELLS = 1000;
            CreateTestFile(NUMBER_OF_TEST_CELLS);
            SaveLoadManager manager = new SaveLoadManager();
            try
            {
                IEnumerable<ICell> cells = manager.LoadFromFile(TESTFILE);
                Assert.AreEqual(NUMBER_OF_TEST_CELLS, cells.Count());
            }
            finally
            {
                DeleteTestFile();
            }
        }

        [TestMethod]
        public void LoadFromFileTest_InvalidFile_ShouldReturnNull()
        {
            SaveLoadManager manager = new SaveLoadManager();
            Assert.AreEqual(null, manager.LoadFromFile("invalidFile" + Guid.NewGuid().ToString()));
        }

        [TestMethod]
        public void SaveToFile_ValidFile_ShouldSaveCorrectly()
        {
            const int NUMBER_OF_TEST_CELLS = 500;
            CreateTestFile(NUMBER_OF_TEST_CELLS);
            SaveLoadManager manager = new SaveLoadManager();
            try
            {
                IEnumerable<ICell> cells = manager.LoadFromFile(TESTFILE);
                Assert.AreEqual(NUMBER_OF_TEST_CELLS, cells.Count());
            }
            finally
            {
                DeleteTestFile();
            }
        }
    }
}