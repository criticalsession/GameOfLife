using System;

namespace GameOfLife.Business
{
    public class Cell
    {
        public bool IsOn { get; set; }

        public void Populate(Char c)
        {
            if (c == 'X' || c == 'x') this.IsOn = true;
        }

        public static Cell GetCell(char isOn)
        {
            Cell newCell = new Cell();
            newCell.Populate(isOn);

            return newCell;
        }
    }
}
