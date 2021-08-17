using System;
using System.Linq;

namespace GameOfLife.Business
{
    public class Cell
    {
        public bool IsAlive { get; set; }

        public bool IsDead
        {
            get
            {
                return !IsAlive;
            }
        }

        public void Populate(Char c)
        {
            if (c == 'X' || c == 'x') this.IsAlive = true;
        }

        public static Cell GetCell(char isOn)
        {
            Cell newCell = new Cell();
            newCell.Populate(isOn);

            return newCell;
        }

        public Cell GetNextState(Cell[] neighbours)
        {
            Cell newState = new Cell();

            int n = neighbours.Where(p => p.IsAlive).Count();
            if (BecomesAlive(n) || RemainsAlive(n)) newState.IsAlive = true;
            else newState.IsAlive = false;

            return newState;
        }

        private bool RemainsAlive(int totalLiveNeighbours)
        {
            return IsAlive && (totalLiveNeighbours == 2 || totalLiveNeighbours == 3);
        }

        private bool BecomesAlive(int totalLiveNeighbours)
        {
            return IsDead && totalLiveNeighbours == 3;
        }
    }
}
