using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Business
{
    public class Board
    {
        public static readonly string ON = "X";
        public static readonly string OFF = "~";

        public static readonly int[] DIRECTION_UPLEFT = { -1, -1 };
        public static readonly int[] DIRECTION_UP = { -1, 0 };
        public static readonly int[] DIRECTION_UPRIGHT = { -1, 1 };
        public static readonly int[] DIRECTION_LEFT = { 0, -1 };
        public static readonly int[] DIRECTION_RIGHT = { 0, 1 };
        public static readonly int[] DIRECTION_DOWNLEFT = { 1, -1 };
        public static readonly int[] DIRECTION_DOWN = { 1, 0 };
        public static readonly int[] DIRECTION_DOWNRIGHT = { 1, 1 };

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

        public string[] Output()
        {
            string[] output = new string[rows];
            for (int r = 0; r < rows; r++)
            {
                string row = "";
                for (int c = 0; c < columns; c++)
                {
                    row += Cells[r, c].IsAlive ? Board.ON : Board.OFF;
                }
                output[r] = row;
            }

            return output;
        }

        public void GetNextState()
        {
            throw new NotPopulatedException();
        }

        public class InvalidStartStringException : Exception
        {
        }

        public class NotPopulatedException : Exception
        {
        }

        public Cell[] GetNeighbours(int row, int column)
        {
            Cell[] neighbours = new Cell[8];
            neighbours[0] = GetNeighbour(row, column, DIRECTION_UPLEFT);
            neighbours[1] = GetNeighbour(row, column, DIRECTION_UP);
            neighbours[2] = GetNeighbour(row, column, DIRECTION_UPRIGHT);
            neighbours[3] = GetNeighbour(row, column, DIRECTION_LEFT);
            neighbours[4] = GetNeighbour(row, column, DIRECTION_RIGHT);
            neighbours[5] = GetNeighbour(row, column, DIRECTION_DOWNLEFT);
            neighbours[6] = GetNeighbour(row, column, DIRECTION_DOWN);
            neighbours[7] = GetNeighbour(row, column, DIRECTION_DOWNRIGHT);
            return neighbours;
        }

        public Cell GetNeighbour(int centralRow, int centralColumn, int[] direction)
        {
            Cell neighbour = new Cell();

            int getRow = centralRow + direction[0];
            int getCol = centralColumn + direction[1];

            if (getRow < 0 || getRow >= rows || getCol < 0 || getCol >= columns)
                neighbour.IsAlive = false;
            else
            {
                neighbour = Cells[getRow, getCol];
            }

            return neighbour;
        }
    }
}
