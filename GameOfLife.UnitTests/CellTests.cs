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
            Assert.IsTrue(cell.IsOn);

            cell = new Cell();
            cell.Populate('X');
            Assert.IsTrue(cell.IsOn);

            cell = new Cell();
            cell.Populate('.');
            Assert.IsFalse(cell.IsOn);
        }

        [Test]
        public void staticGetCell_givenValue_returnsCell()
        {
            Assert.IsTrue(Cell.GetCell('x').IsOn);
            Assert.IsFalse(Cell.GetCell('o').IsOn);
        }
    }
}