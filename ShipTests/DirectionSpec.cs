using System;
using NUnit.Framework;
using ShipTdd;

namespace ShipTests {
    [TestFixture]
    public class DirectionSpec {
        [Test]
        public void WhenGetFromShortNameCapitalNThenReturnDirectionN() {
            var direction = DirectionExtension.GetFromShortName<Direction>("N");
            Assert.AreEqual(Direction.North, direction);
        }

        [Test]
        public void WhenGetFromShortNameSmallNThnReturnDirectionW() {
            var direction = DirectionExtension.GetFromShortName<Direction>("n");
            Assert.AreEqual(Direction.North, direction);
        }

        [Test]
        public void WhenGetFromShortNameDThenReturnDirectionNone() {
            var direction = DirectionExtension.GetFromShortName<Direction>("D");
            Assert.AreEqual(Direction.None, direction);
        }

        [Test]
        public void GivenSWhenLeftThenE() {
            Assert.AreEqual(Direction.East, Direction.South.TurnLeft());
        }
        [Test]
        public void GivenNWhenLeftThenW() {
            Assert.AreEqual(Direction.West, Direction.North.TurnLeft());
        }
        [Test]
        public void GivenSWhenRightThenW() {
            Assert.AreEqual(Direction.West, Direction.South.TurnRight());
        }
        [Test]
        public void GivenWWhenRightThenN() {
            Assert.AreEqual(Direction.North, Direction.West.TurnRight());
        }


    }
}
