using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Interfaces;
using CellSimulator.Models;
using System.IO;
using CellSimulator.Enums;

namespace CellSimulator.Logic
{
    public class SaveLoadManager : ISaveLoadManager
    {
        private const char SEPARATION_CHAR = '|';

        public IEnumerable<ICell> LoadFromFile(string fileName)
        {
            if (FileExists(fileName))
            {
                return LoadCellList(fileName);
            }
            return null;
        }

        private bool FileExists(string fileName)
        {
            return File.Exists(fileName);
        }

        private IEnumerable<ICell> LoadCellList(string fileName)
        {
            List<ICell> cells = new List<ICell>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string[] currentLineValues;
                while (!reader.EndOfStream)
                {
                    currentLineValues = reader.ReadLine().Split(SEPARATION_CHAR);
                    cells.Add(new Models.Cell()
                    {
                        ID = int.Parse(currentLineValues[0]),
                        Age = int.Parse(currentLineValues[1]),
                        Food = int.Parse(currentLineValues[2]),
                        MaxFood = int.Parse(currentLineValues[3]),
                        Energy = int.Parse(currentLineValues[4]),
                        MaxEnergy = int.Parse(currentLineValues[5]),
                        LastAction = (CellActionEnum)Enum.Parse(typeof(CellActionEnum), currentLineValues[6])
                    });
                }
            }
            return cells;
        }

        public void SaveToFile(string fileName, IEnumerable<ICell> cells)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (ICell cell in cells)
                {
                    writer.WriteLine(string.Join(SEPARATION_CHAR.ToString(),
                        new object[] { cell.ID, cell.Age, cell.Food, cell.MaxFood, cell.Energy, cell.MaxEnergy, cell.LastAction }));
                }
            }
        }
    }
}
