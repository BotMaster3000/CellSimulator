using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CellSimulator
{
    public class CellOverseer
    {
        Random rand = new Random();
        public List<Cell> cells = new List<Cell>();
        public int cellIdCounter = 0;

        public CellOverseer(int startingCells)
        {
            for (int i = 0; i < startingCells; ++i)
            {
                AddNewCell(cells);
            }
        }
        public void AddNewCell(List<Cell> cellList)
        {
            cellList.Add(new Cell(cellIdCounter));
            ++cellIdCounter;
        }
        public void SimulateNext()
        {
            List<Cell> stillAliveCells = new List<Cell>();
            foreach (Cell cell in cells)
            {
                if (cell.energy <= 0 || cell.food <= 0)
                {
                    continue;
                }
                if (cell.food >= 60)
                {
                    if (cell.Split(rand))
                    {
                        AddNewCell(stillAliveCells);
                        cell.food -= 50;
                        cell.energy -= 20;
                        cell.lastAction = "SuccessSplit";
                    }
                    else
                    {
                        cell.lastAction = "FailSplit";
                    }
                    cell.energy -= 10;
                }
                else
                {
                    if (cell.Eat(rand))
                    {
                        cell.lastAction = "SuccessEat";
                    }
                    else
                    {
                        cell.lastAction = "FailEat";
                    }
                }
                cell.energy -= 5;
                cell.food -= 5;
                if (cell.energy <= 0 || cell.food <= 0)
                {
                    continue;
                }
                cell.age += 1;
                stillAliveCells.Add(cell);
            }
            cells = stillAliveCells;
        }
        public void SaveToFile()
        {
            List<string> linesToAppend = new List<string>();
            foreach (Cell cell in cells)
            {
                string lineToAppend = cell.id + "|" + cell.age + "|" + cell.food + "|" + cell.maxFood + "|" + cell.energy + "|" + cell.maxEnergy + "|" + cell.lastAction;
                linesToAppend.Add(lineToAppend);
            }
            string nameAppender = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            File.AppendAllLines("CellList-" + nameAppender + ".txt", linesToAppend);
        }
        public bool LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }

            List<Cell> listOfCells = new List<Cell>();
            string[] dataLines = File.ReadAllLines(fileName);
            foreach (string dataLine in dataLines)
            {
                string[] splitDataLine = dataLine.Split('|');
                Cell tempCell = new Cell(cellIdCounter)
                {
                    id = Convert.ToInt32(splitDataLine[0]),
                    age = Convert.ToInt32(splitDataLine[1]),
                    food = Convert.ToInt32(splitDataLine[2]),
                    maxFood = Convert.ToInt32(splitDataLine[3]),
                    energy = Convert.ToInt32(splitDataLine[4]),
                    maxEnergy = Convert.ToInt32(splitDataLine[5]),
                    lastAction = splitDataLine[6]
                };
                listOfCells.Add(tempCell);
            }
            cells = listOfCells;

            return true;
        }
    }
}
