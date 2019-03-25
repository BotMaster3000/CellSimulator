using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Logic;

namespace CellSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulationManager manager = new SimulationManager();
            manager.StartSimulation();
            return;

            bool showCellInfo = true;
            CellOverseer overseer = new CellOverseer(1);
            while (true)
            {
                if (showCellInfo)
                {
                    foreach (Cell cell in overseer.cells)
                    {
                        Console.WriteLine("ID:" + cell.id + "|AGE:" + cell.age + "|FOOD:" + cell.food + "|ENERGY:" + cell.energy + "|ACTION:" + cell.lastAction);
                    }
                }
                Console.WriteLine("ALIVE:" + overseer.cells.Count());
                string commandEntered = Console.ReadLine().ToLower();
                if (!string.IsNullOrEmpty(commandEntered))
                {
                    switch (commandEntered)
                    {
                        case "save":
                            overseer.SaveToFile();
                            continue;
                        case "load":
                            string fileName = Console.ReadLine();
                            if (string.IsNullOrEmpty(fileName))
                            {
                                continue;
                            }
                            else
                            {
                                overseer.LoadFromFile(fileName);
                            }
                            break;
                        case "switchshowinfo":
                            showCellInfo = !showCellInfo;
                            break;
                    }
                }

                overseer.SimulateNext();
                Console.WriteLine();
            }
        }
    }
}
