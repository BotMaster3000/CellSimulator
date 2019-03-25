using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Interfaces;
using CellSimulator.Input;
using CellSimulator.Enums;
using CellSimulator.Output;

namespace CellSimulator.Logic
{
    public class SimulationManager : ISimulationManager
    {
        private readonly ICellOverseer Overseer = new CellOverseer();
        private readonly ISaveLoadManager SaverLoader = new SaveLoadManager();
        private readonly IUserActionManager InputManager = new ConsoleInputManager();
        private readonly ICellPrinter OutputManager = new ConsoleCellPrinter();

        private bool ShowAllInfo = true;

        public void StartSimulation()
        {
            SetInitialPopulation();
            while (true)
            {
                if (ShowAllInfo)
                {
                    OutputManager.PrintCells(Overseer.CellList);
                }
                OutputManager.PrintCellCount(Overseer.CellList);
                switch (InputManager.GetUserAction())
                {
                    case UserActionEnum.LOAD:
                        Overseer.CellList = (List<ICell>)SaverLoader.LoadFromFile(InputManager.GetUserFileName());
                        break;
                    case UserActionEnum.SAVE:
                        SaverLoader.SaveToFile(InputManager.GetUserFileName(), Overseer.CellList);
                        break;
                    case UserActionEnum.SWITCHSHOWINFO:
                        ShowAllInfo = !ShowAllInfo;
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
            for (int i = 0; i < cellCount; ++i)
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
