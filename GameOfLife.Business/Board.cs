using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Business
{
    public class Board
    {
        private int rows;
        private int columns;

        public Cell[,] Cells;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            Cells = new Cell[rows, columns];
        }

        public void Populate(string startString)
        {
            string[] startRows = CheckAndSplitStartString(startString);

            int rowCount = 0;
            foreach (string row in startRows)
            {
                int colCount = 0;

                foreach (Char c in row)
                    Cells[rowCount, colCount++] = Cell.GetCell(c);

                rowCount++;
            }
        }

        private string[] CheckAndSplitStartString(string startString)
        {
            string[] startRows = startString.Split(',');

            if (startRows.Length != this.rows) throw new InvalidStartStringException();
            foreach (string r in startRows)
                if (r.Length != this.columns) throw new InvalidStartStringException();

            return startRows;
        }

        public class InvalidStartStringException : Exception
        {
        }
    }
}
