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
        public int ID { get; set; }
        public int Age { get; set; }
        public int Food { get; set; }
        public int MaxFood { get; set; }
        public int Energy { get; set; }
        public int MaxEnergy { get; set; }
        public ActionEnum LastAction { get; set; }

        private const double PROPABILITY_EAT_FOOD = 0.25;
        private const int INCREMENTOR_EAT_FOOD = 40;

        private const double PROPABILITY_SPLIT = 0.25;

        private Random rand;

        public Cell(int id = 0, Random rand = null)
        {
            ID = id;
            this.rand = rand ?? new Random();
        }

        public bool TryEat()
        {
            bool didEat = rand.NextDouble() <= PROPABILITY_EAT_FOOD;
            if(didEat)
            {
                IncrementFood();
            }
            return didEat;
        }

        private void IncrementFood()
        {
            if((Food += INCREMENTOR_EAT_FOOD) > MaxFood)
            {
                Food = MaxFood;
            }
        }

        public bool TrySplit()
        {
            return rand.NextDouble() <= PROPABILITY_SPLIT;
        }
    }
}
