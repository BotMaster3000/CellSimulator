using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellSimulator
{
    public class Cell
    {
        Random rand = new Random();

        public int id;
        public int age = 0;

        public int food = 100;
        public int maxFood = 100;

        public int energy = 100;
        public int maxEnergy = 100;
        
        public Cell(int cellId)
        {
            id = cellId;
        }

        public void Eat()
        {
            bool didEat = false;
            if(rand.Next(0, 101) > 75)
            {
                didEat = true;
            }
            if (didEat)
            {
                food += 10;
            }
            if(food > maxFood)
            {
                food = maxFood;
            }
        }
        public bool Split()
        {
            bool didSplit = false;
            if(rand.Next(0, 101) > 75)
            {
                didSplit = true;
            }            
            return didSplit;
        }
    }
}
