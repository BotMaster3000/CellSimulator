using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellSimulator.Interfaces
{
    public interface ICellOverseer
    {
        List<ICell> CellList { get; }

        void AddCell();
        void AddCell(ICell cell);
        void SimulateNext();
    }
}
