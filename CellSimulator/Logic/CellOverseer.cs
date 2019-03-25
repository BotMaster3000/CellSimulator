using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Interfaces;
using CellSimulator.Models;

namespace CellSimulator.Logic
{
    public class CellOverseer : ICellOverseer
    {
        public List<ICell> CellList { get; set; } = new List<ICell>();
        private int internalIdCounter;

        private readonly Random rand = new Random();

        public void AddCell()
        {
            AddCell(new Models.Cell(internalIdCounter, rand));
            ++internalIdCounter;
        }

        public void AddCell(ICell cell)
        {
            CellList.Add(cell);
        }

        public void SimulateNext()
        {
            List<ICell> CellsToRemove = new List<ICell>();
            int cellCount = CellList.Count; // Might get bigger during for-Loop, but New Cells should only be Evaluated in next run
            for (int i = 0; i < cellCount; i++)
            {
                ICell cell = CellList[i];
                cell.PerformAction();
                if (!cell.IsAlive)
                {
                    CellsToRemove.Add(cell);
                }
                else if (cell.LastAction == Enums.CellActionEnum.SuccessSplit)
                {
                    AddCell();
                }
            }
            foreach(ICell cell in CellsToRemove)
            {
                CellList.Remove(cell);
            }
        }
    }
}
