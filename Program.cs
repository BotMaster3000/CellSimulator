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
            CellOverseer overseer = new CellOverseer(1);
            while (true)
            {
                foreach(Cell cell in overseer.cells)
                {
                    Console.WriteLine("ID:" + cell.id + "|AGE:" + cell.age + "|FOOD:" + cell.food + "|ENERGY:" + cell.energy + "|ACTION:" + cell.lastAction);
                }
                Console.WriteLine("ALIVE:" + overseer.cells.Count());
                string keyPressed = Console.ReadLine();
                if(keyPressed != "")
                {
                    if(keyPressed == "save")
                    {
                        overseer.SaveToFile();
                        continue;
                    }
                    else if(keyPressed == "load")
                    {
                        string fileName = Console.ReadLine();
                        if(fileName == "")
                        {
                            continue;
                        }
                        else
                        {
                            overseer.LoadFromFile(fileName);
                        }
                    }
                }

                overseer.SimulateNext();
                Console.WriteLine();
            }
        }
    }
}
