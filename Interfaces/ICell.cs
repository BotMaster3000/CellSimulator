using CellSimulator.Enums;

namespace CellSimulator.Interfaces
{
    public interface ICell
    {
        int ID { get; set; }
        int Age { get; set; }
        int Food { get; set; }
        int MaxFood { get; set; }
        int Energy { get; set; }
        int MaxEnergy { get; set; }
        ActionEnum LastAction { get; set; }
        bool IsAlive { get; set; }

        bool TrySplit();
        bool TryEat();
        void PerformAction();
    }
}
