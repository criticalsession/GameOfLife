using GameOfLife.Business;
using NUnit.Framework;

namespace GameOfLife.UnitTests
{
    public class BoardTests
    {
        [Test]
        public void constructor_givenMRowsAndNColumns_initialisedArray()
        {
            int rows = 10;
            int columns = 20;

            Board board = new Board(rows, columns);

            Assert.AreEqual(rows * columns, board.Cells.Length);
            Assert.AreEqual(rows, board.Cells.GetLength(0));
            Assert.AreEqual(columns, board.Cells.GetLength(1));
        }

        [Test]
        public void populate_givenStartString_populatesArrayWithCells()
        {
            Board board = new Board(5,5);

            string startString = "x..xx,..x..,..x..,xxx..,xxxxx";
            board.Populate(startString);

            Assert.IsTrue(board.Cells[0, 0].IsAlive);
            Assert.IsFalse(board.Cells[2, 3].IsAlive);
        }

        [Test]
        public void populate_givenInvalidStartString_throwsInvalidStartStringException()
        {
            Board board = new Board(5, 5);

            Assert.Throws<Board.InvalidStartStringException>(() =>
            {
                string startString = "x..xx,.xxx.x..,..x..,xxx..,xxxxx";
                board.Populate(startString);
            });

            Assert.Throws<Board.InvalidStartStringException>(() =>
            {
                string startString = "x..xx";
                board.Populate(startString);
            });
        }

        [Test]
        public void output_afterInitialisation_outputsCorrectStrings()
        {
            Board board = new Board(4, 5);
            string startString = "x..xx,..x..,..x..,xxx..";
            board.Populate(startString);

            string[] output = board.Output();
            Assert.AreEqual(4, output.Length);
            Assert.AreEqual(5, output[0].Length);

            Assert.AreEqual(string.Format("{0}{1}{1}{0}{0}", Board.ON, Board.OFF), output[0]); // x..xx
            Assert.AreEqual(string.Format("{1}{1}{0}{1}{1}", Board.ON, Board.OFF), output[2]); // ..x..
        }

        [Test]
        public void getNextState_boardIsNotPopulated_throwsNotPopulateException()
        {
            Board board = new Board(4, 5);

            Assert.Throws<Board.NotPopulatedException>(() =>
            {
                board.GetNextState();
            });
        }

        [Test]
        public void getNextState_boardIsPopulated_updatesBoardWithNewState()
        {
            Board board = new Board(5, 5);
            string startString = "x..xx,..x..,..x..,xxx..,xxxxx";
            board.Populate(startString);
            board.GetNextState();
            
            string[] output = board.Output();

            Assert.AreEqual(string.Format("{0}{0}{0}{1}{0}", Board.OFF, Board.ON), output[0]);
            Assert.AreEqual(string.Format("{0}{1}{1}{0}{0}", Board.OFF, Board.ON), output[1]);
            Assert.AreEqual(string.Format("{0}{0}{1}{1}{0}", Board.OFF, Board.ON), output[2]);
            Assert.AreEqual(string.Format("{1}{0}{0}{0}{0}", Board.OFF, Board.ON), output[3]);
            Assert.AreEqual(string.Format("{1}{0}{0}{1}{0}", Board.OFF, Board.ON), output[4]);
        }

        [Test]
        public void getNeighbour_givenCentralCellAndDirection_returnsCorrectNeighbour()
        {
            Board board = new Board(5, 5);
            string startString = "x..xx,..x..,..x..,xxx..,xxxxx";
            board.Populate(startString);

            Assert.True(board.GetNeighbour(2, 1, Board.DIRECTION_UP).IsDead);
            Assert.True(board.GetNeighbour(0, 3, Board.DIRECTION_DOWNLEFT).IsAlive);
            Assert.True(board.GetNeighbour(0, 0, Board.DIRECTION_UPRIGHT).IsDead);
        }

        [Test]
        public void getNeighbours_boardIsPopulated_returnsCorrectArrayOfEightNeighbours()
        {
            Board board = new Board(5, 5);
            string startString = "x..xx,..x..,..x..,xxx..,xxxxx";
            board.Populate(startString);

            Cell[] neighbours = board.GetNeighbours(2, 1);
            Assert.AreEqual(8, neighbours.Length);

            Assert.True(neighbours[0].IsDead);
            Assert.True(neighbours[1].IsDead);
            Assert.True(neighbours[2].IsAlive);
            Assert.True(neighbours[3].IsDead);
            Assert.True(neighbours[4].IsAlive);
            Assert.True(neighbours[5].IsAlive);
            Assert.True(neighbours[6].IsAlive);
            Assert.True(neighbours[7].IsAlive);
        }

        [Test]
        public void getCell_unpopulatedBoard_throwsNotPopulatedException()
        {
            Board board = new Board(5, 5);

            Assert.Throws<Board.NotPopulatedException>(() =>
            {
                board.GetCell(0, 0);
            });
        }

        [Test]
        public void getCell_givenRowAndColumn_returnsCorrectCell()
        {
            Board board = new Board(5, 5);
            string startString = "x..xx,..x..,..x..,xxx..,xxxxx";
            board.Populate(startString);

            Assert.IsTrue(board.GetCell(0, 3).IsAlive);
            Assert.IsTrue(board.GetCell(2, 1).IsDead);
        }
    }
}