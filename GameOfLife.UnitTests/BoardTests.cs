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

            Assert.IsTrue(board.Cells[0, 0].IsOn);
            Assert.IsFalse(board.Cells[2, 3].IsOn);
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

            Assert.AreEqual(string.Format("{0}{1}{1}{0}{0}", Board.ON, Board.OFF), output[0]);
            Assert.AreEqual(string.Format("{1}{1}{0}{1}{1}", Board.ON, Board.OFF), output[2]);
        }
    }
}