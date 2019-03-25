using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellSimulator
{
    public class Cell
    {
        public int id;
        public int age = 0;

        public int food = 100;
        public int maxFood = 100;

        public int energy = 100;
        public int maxEnergy = 100;

        public string lastAction = "Born";

        public Cell(int cellId)
        {
            id = cellId;
        }

        public bool Eat(Random rand)
        {
            bool didEat = false;
            if (rand.Next(0, 101) > 75)
            {
                didEat = true;
            }
            if (didEat)
            {
                food += 40;
            }
            if (food > maxFood)
            {
                food = maxFood;
            }
            return didEat;
        }
        public bool Split(Random rand)
        {
            bool didSplit = false;
            if (rand.Next(0, 101) > 75)
            {
                didSplit = true;
            }
            return didSplit;
        }
    }
}
