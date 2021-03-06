﻿using System;
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
        public int Food { get; set; } = 100;
        public int MaxFood { get; set; } = 100;
        public int Energy { get; set; } = 100;
        public int MaxEnergy { get; set; } = 100;
        public CellActionEnum LastAction { get; set; }
        public bool IsAlive { get; set; } = true;

        private const double PROPABILITY_EAT_FOOD = 0.25;
        private const int INCREMENTOR_EAT_FOOD = 40;

        private const double PROPABILITY_SPLIT = 0.25;

        private const int FOOD_REQUIRED_FOR_SUCCESSFUL_SPLIT = 50;
        private const int ENERGY_REQUIRED_FOR_SPLIT = 20;
        private const int FOOD_REQUIRED_FOR_TRY_SPLIT = 10;

        private const int FOOD_CONSUMED_PER_ACTION = 5;
        private const int ENERGY_CONSUMED_PER_ACTION = 5;

        private readonly Random rand;

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

        public void PerformAction()
        {
            if(Food >= FOOD_REQUIRED_FOR_SUCCESSFUL_SPLIT + FOOD_REQUIRED_FOR_TRY_SPLIT)
            {
                if (TrySplit())
                {
                    LastAction = CellActionEnum.SuccessSplit;
                    Food -= FOOD_REQUIRED_FOR_SUCCESSFUL_SPLIT;
                    Energy -= ENERGY_REQUIRED_FOR_SPLIT;
                }
                else
                {
                    LastAction = CellActionEnum.FailSplit;
                }
                Food -= FOOD_REQUIRED_FOR_TRY_SPLIT;
            }
            else
            {
                if (TryEat())
                {
                    LastAction = CellActionEnum.SuccessEat;
                }
                else
                {
                    LastAction = CellActionEnum.FailEat;
                }
            }
            Energy -= FOOD_CONSUMED_PER_ACTION;
            Food -= ENERGY_CONSUMED_PER_ACTION;
            CheckIfDead();
            ++Age;
        }

        private void CheckIfDead()
        {
            if(Energy <= 0 || Food <= 0)
            {
                IsAlive = false;
            }
        }
    }
}
