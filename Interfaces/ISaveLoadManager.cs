using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellSimulator.Interfaces
{
    public interface ISaveLoadManager
    {
        void SaveToFile(string fileName, IEnumerable<ICell> cells);
        IEnumerable<ICell> LoadFromFile(string fileName);
    }
}
