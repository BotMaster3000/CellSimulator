using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Enums;

namespace CellSimulator.Interfaces
{
    public interface IUserActionManager
    {
        UserActionEnum GetUserAction();
    }
}
