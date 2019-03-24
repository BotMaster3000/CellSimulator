using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Enums;
using CellSimulator.Interfaces;

namespace CellSimulator.Models
{
    public class Cell : ICell
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Food { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxFood { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Energy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxEnergy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ActionEnum LastAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Split()
        {
            throw new NotImplementedException();
        }

        public bool TrySplit()
        {
            throw new NotImplementedException();
        }
    }
}
