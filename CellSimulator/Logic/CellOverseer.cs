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
        public List<ICell> CellList { get; private set; } = new List<ICell>();
        private int internalIdCounter = 0;

        private Random rand = new Random();

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
            for (int i = 0; i < CellList.Count; i++)
            {
                ICell cell = CellList[i];
                cell.PerformAction();
                if (!cell.IsAlive)
                {
                    CellList.Remove(cell);
                }
                else if(cell.LastAction == Enums.CellActionEnum.SuccessSplit)
                {
                    AddCell();
                }
            }
        }
    }
}
