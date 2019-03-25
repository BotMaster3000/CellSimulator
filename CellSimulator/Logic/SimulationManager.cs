using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Interfaces;
using CellSimulator.Input;
using CellSimulator.Enums;

namespace CellSimulator.Logic
{
    public class SimulationManager : ISimulationManager
    {
        private readonly CellOverseer Overseer = new CellOverseer();
        private readonly SaveLoadManager SaveLoadmanager = new SaveLoadManager();
        private readonly ConsoleInputManager InputManager = new ConsoleInputManager();

        public void StartSimulation()
        {
            SetInitialPopulation();
            while (true)
            {
                switch (InputManager.GetUserAction())
                {
                    case UserActionEnum.LOAD:
                        Overseer.CellList = (List<ICell>)SaveLoadmanager.LoadFromFile(InputManager.GetUserFileName());
                        break;
                    case UserActionEnum.SAVE:
                        SaveLoadmanager.SaveToFile(InputManager.GetUserFileName(), Overseer.CellList);
                        break;
                    case UserActionEnum.SWITCHSHOWINFO:
                        break;
                    case UserActionEnum.INVALID:
                        Overseer.SimulateNext();
                        break;
                }
            }
        }

        private void SetInitialPopulation()
        {
            int cellCount = GetStartingCellCount();
            for(int i = 0; i < cellCount; ++i)
            {
                Overseer.AddCell();
            }
        }

        private int GetStartingCellCount()
        {
            int cellCount = -1;
            while (cellCount <= 0)
            {
                cellCount = InputManager.GetStartingCellCount();
            }
            return cellCount;
        }
    }
}
