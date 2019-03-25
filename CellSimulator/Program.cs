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
        static void Main()
        {
            SimulationManager manager = new SimulationManager();
            manager.StartSimulation();
        }
    }
}
