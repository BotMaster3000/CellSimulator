using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
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
                if (commandEntered != "")
                {
                    if (commandEntered == "save")
                    {
                        overseer.SaveToFile();
                        continue;
                    }
                    else if (commandEntered == "load")
                    {
                        string fileName = Console.ReadLine();
                        if (fileName == "")
                        {
                            continue;
                        }
                        else
                        {
                            overseer.LoadFromFile(fileName);
                        }
                    }
                    else if (commandEntered == "switchshowinfo")
                    {
                        showCellInfo = !showCellInfo;
                    }
                }

                overseer.SimulateNext();
                Console.WriteLine();
            }
        }
    }
}
