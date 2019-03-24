using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Interfaces;

namespace CellSimulator.Models
{
    public class CellOverseer : ICellOverseer
    {
        public List<ICell> CellList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddCell()
        {
            throw new NotImplementedException();
        }

        public void SimulateNext()
        {
            throw new NotImplementedException();
        }
    }
}
