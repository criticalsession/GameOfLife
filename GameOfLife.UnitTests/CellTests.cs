using GameOfLife.Business;
using NUnit.Framework;

namespace GameOfLife.UnitTests
{
    public class CellTests
    {
        public Cell cell;

        [SetUp]
        public void Setup()
        {
            cell = new Cell();
        }

        [Test]
        public void getCellFromCharacter_givenValue_populatesIsOn()
        {
            cell.Populate('x');
            Assert.IsTrue(cell.IsAlive);

            cell = new Cell();
            cell.Populate('X');
            Assert.IsTrue(cell.IsAlive);

            cell = new Cell();
            cell.Populate('.');
            Assert.IsFalse(cell.IsAlive);
        }

        [Test]
        public void staticGetCell_givenValue_returnsCell()
        {
            Assert.IsTrue(Cell.GetCell('x').IsAlive);
            Assert.IsFalse(Cell.GetCell('o').IsAlive);
        }
    
        [Test]
        public void getNextState_givenSection_returnsCell()
        {
            Cell newState = cell.GetNextState(GetNeighbours(2));

            Assert.IsInstanceOf(typeof(Cell), cell);
        }

        [Test]
        public void getNextState_aliveFewerThanTwoLiveNeighbours_cellDies()
        {
            cell.IsAlive = true;
            Assert.False(cell.GetNextState(GetNeighbours(1)).IsAlive);
            Assert.False(cell.GetNextState(GetNeighbours(0)).IsAlive);
        }

        [Test]
        public void getNextState_aliveTwoOrThreeLiveNeighbours_cellLives()
        {
            cell.IsAlive = true;
            Assert.True(cell.GetNextState(GetNeighbours(2)).IsAlive);
            Assert.True(cell.GetNextState(GetNeighbours(3)).IsAlive);
        }

        [Test]
        public void getNextState_aliveMoreThanThreeLiveNeighbours_cellDies()
        {
            cell.IsAlive = true;
            Assert.False(cell.GetNextState(GetNeighbours(4)).IsAlive);
            Assert.False(cell.GetNextState(GetNeighbours(5)).IsAlive);
            Assert.False(cell.GetNextState(GetNeighbours(8)).IsAlive);
        }

        [Test]
        public void getNextState_deadExactlyThreeLiveNeighbours_cellLives()
        {
            cell.IsAlive = false;
            Assert.False(cell.GetNextState(GetNeighbours(2)).IsAlive);
            Assert.True(cell.GetNextState(GetNeighbours(3)).IsAlive);
            Assert.False(cell.GetNextState(GetNeighbours(4)).IsAlive);
        }

        private Cell[] GetNeighbours(int liveNeighbours)
        {
            Cell[] cells = new Cell[8];

            for (int i = 0; i < 8; i++)
            {
                Cell neighbour = new Cell();
                if (liveNeighbours > 0)
                {
                    neighbour.IsAlive = true;
                    liveNeighbours--;
                }

                cells[i] = neighbour;
            }

            return cells;
        }
    }
}