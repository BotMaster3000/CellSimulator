using Microsoft.VisualStudio.TestTools.UnitTesting;
using CellSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Enums;

namespace CellSimulator.Models.Tests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void IdPropertyTest()
        {
            const int testValue = 123;
            Cell cell = new Cell() { ID = testValue };
            Assert.AreEqual(testValue, cell.ID);
        }

        [TestMethod]
        public void AgePropertyTest()
        {
            const int testValue = 123;
            Cell cell = new Cell() { Age = testValue };
            Assert.AreEqual(testValue, cell.Age);
        }

        [TestMethod]
        public void FoodPropertyTest()
        {
            const int testValue = 24;
            Cell cell = new Cell() { Food = testValue };
            Assert.AreEqual(testValue, cell.Food);
        }

        [TestMethod]
        public void MaxFoodPropertyTest()
        {
            const int testValue = 86;
            Cell cell = new Cell() { MaxFood = testValue };
            Assert.AreEqual(testValue, cell.MaxFood);
        }

        [TestMethod]
        public void EnergyPropertyTest()
        {
            const int testValue = 72;
            Cell cell = new Cell() { Energy = testValue };
            Assert.AreEqual(testValue, cell.Energy);
        }

        [TestMethod]
        public void MaxEnergyPropertyTest()
        {
            const int testValue = 15;
            Cell cell = new Cell() { MaxEnergy = testValue };
            Assert.AreEqual(testValue, cell.MaxEnergy);
        }

        [TestMethod]
        public void LastActionPropertyTest()
        {
            const CellActionEnum actionEnum = CellActionEnum.Born;
            Cell cell = new Cell() { LastAction = actionEnum };
            Assert.AreEqual(actionEnum, cell.LastAction);
        }

        [TestMethod]
        public void IsAlivePropertyTest()
        {
            Cell cell = new Cell();
            Assert.AreEqual(true, cell.IsAlive);
            cell.IsAlive = false;
            Assert.AreEqual(false, cell.IsAlive);
        }

        [TestMethod]
        public void CellConstructorTest()
        {
            int id = 100;
            Random rand = new Random();
            Cell cell = new Cell(id, rand);
        }

        [TestMethod]
        public void TryEatTest_ValueCorrectlyIncreased()
        {
            const int startingFoodValue = 0;
            const int maxFoodValue = 100;
            const int totalRuns = 1000;

            Random rand = new Random();

            for (int i = 0; i < totalRuns; ++i)
            {
                Cell cell = new Cell(100, rand)
                {
                    Food = startingFoodValue,
                    MaxFood = maxFoodValue,
                };
                bool didEat = cell.TryEat();
                if (didEat)
                {
                    Assert.IsTrue(cell.Food > startingFoodValue);
                }
                else
                {
                    Assert.AreEqual(startingFoodValue, cell.Food);
                }
            }
        }

        [TestMethod]
        public void TrySplitTest_BothResultsPossible()
        {
            const int TOTAL_RUNS = 1000;
            bool didSucceedSplitting = false;
            bool didFailSplitting = false;

            Random rand = new Random();

            for (int i = 0; i < TOTAL_RUNS; ++i)
            {
                Cell cell = new Cell(100, rand);
                bool didSplit = cell.TrySplit();
                if (didSplit)
                {
                    didSucceedSplitting = true;
                }
                else
                {
                    didFailSplitting = true;
                }
            }

            Assert.IsTrue(didSucceedSplitting);
            Assert.IsTrue(didFailSplitting);
        }

        [TestMethod]
        public void PerformActionTest_ShouldTrySplit()
        {
            const int TOTAL_RUNS = 1000;
            Random rand = new Random();
            for (int i = 0; i < TOTAL_RUNS; ++i)
            {
                Cell cell = new Cell(1, rand) { Food = 100, MaxFood = 100 };
                cell.PerformAction();
                Assert.IsTrue(cell.LastAction == CellActionEnum.SuccessSplit || cell.LastAction == CellActionEnum.FailSplit);
            }
        }

        [TestMethod]
        public void PerformActionTest_ShouldTryEat()
        {
            const int TOTAL_RUNS = 1000;
            Random rand = new Random();
            for (int i = 0; i < TOTAL_RUNS; ++i)
            {
                Cell cell = new Cell(1, rand) { Food = 0, MaxFood = 100 };
                cell.PerformAction();
                Assert.IsTrue(cell.LastAction == CellActionEnum.SuccessEat || cell.LastAction == CellActionEnum.FailEat);
            }
        }
    }
}