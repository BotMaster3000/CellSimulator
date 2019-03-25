using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSimulator.Enums;
using CellSimulator.Interfaces;

namespace CellSimulator.Input
{
    public class ConsoleInputManager : IUserActionManager
    {
        public UserActionEnum GetUserAction()
        {
            Console.Write("Enter Action: ");
            if (Enum.TryParse(Console.ReadLine().ToUpper(), out UserActionEnum result))
            {
                return result;
            }
            else
            {
                return UserActionEnum.INVALID;
            }

        }
    }
}
