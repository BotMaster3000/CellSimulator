using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellSimulator
{
    public class CellOverseer
    {
        public List<Cell> cells = new List<Cell>();
        public int cellIdCounter = 0;

        public CellOverseer(int startingCells)
        {
            for(int i = 0; i < startingCells; ++i)
            {
                cells.Add(new Cell(cellIdCounter));
                ++cellIdCounter;
            }
        }
        public void SimulateNext()
        {
            List<Cell> stillAliveCells = new List<Cell>();
            foreach(Cell cell in cells)
            {
                if(cell.energy <= 0)
                {
                    continue;
                }
                if(cell.food > 80)
                {

                }
                else
                {
                    cell.Eat();
                }
                stillAliveCells.Add(cell);
            }
        }
    }
}
