using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ShipTdd;

namespace ShipTests {
    [TestFixture]
    public class LocationSpec {

        private const int x = 12;
        private const int y = 32;
        private const Direction direction = Direction.North;
        private Point max;
        private Location location;
        private List<Point> obstacles;

        [SetUp]
        public void beforeTest() {
            max = new Point(50, 50);
            location = new Location(new Point(x, y), direction);
            obstacles = new List<Point>();
        }

        [Test]
        public void whenInstantiatedThenXIsStored() {
            Assert.AreEqual(location.X, x);
        }
        [Test]
        public void whenInstantiatedThenYIsStored() {
            Assert.AreEqual(location.Y, y);
        }
        [Test]
        public void whenInstantiatedThenDirectionIsStored() {
            Assert.AreEqual(location.Direction, direction);
        }
        [Test]
        public void givenDirectionNWhenForwardThanYDecreases() {
            location.Forward(max, obstacles);
            Assert.AreEqual(location.Y, y - 1);
        }
        [Test]
        public void givenDirectionSWhenForwardThanYIncreases() {
            location.Direction = Direction.South;
            location.Forward(max, obstacles);
            Assert.AreEqual(location.Y, y + 1);
        }
        [Test]
        public void givenDirectionEWhenForwardThanXIncreases() {
            location.Direction = Direction.East;
            location.Forward(max, obstacles);
            Assert.AreEqual(location.X, x + 1);
        }
        [Test]
        public void givenDirectionWWhenForwardThanXDecreases() {
            location.Direction = Direction.West;
            location.Forward(max, obstacles);
            Assert.AreEqual(location.X, x - 1);
        }
        [Test]
        public void givenDirectionNWhenBackwardThanYIncreases() {
            location.Direction = Direction.North;
            location.Backward(max, obstacles);
            Assert.AreEqual(location.Y, y + 1);
        }
        [Test]
        public void givenDirectionSWhenBackwardThanYDecreases() {
            location.Direction = Direction.South;
            location.Backward(max, obstacles);
            Assert.AreEqual(location.Y, y - 1);
        }
        [Test]
        public void givenDirectionEWhenBackwardThanXDecreases() {
            location.Direction = Direction.East;
            location.Backward(max, obstacles);
            Assert.AreEqual(location.X, x - 1);
        }
        [Test]
        public void givenDirectionWWhenBackwardThanXIncreases() {
            location.Direction = Direction.West;
            location.Backward(max, obstacles);
            Assert.AreEqual(location.X, x + 1);
        }
        [Test]
        public void whenTurnLeftThenDirectionIsSet() {
            location.TurnLeft();
            Assert.AreEqual(location.Direction, Direction.West);
        }
        [Test]
        public void whenTurnRightThenDirectionIsSet() {
            location.TurnRight();
            Assert.AreEqual(location.Direction, Direction.East);
        }
        [Test]
        public void givenSameObjectsWhenEqualsThenTrue() {
            Assert.True(location.Equals(location));
        }
        [Test]
        public void givenDifferentObjectWhenEqualsThenFalse() {
            Assert.False(location.Equals("bla"));
        }
        [Test]
        public void givenDifferentXWhenEqualsThenFalse() {
            Location locationCopy = new Location(new Point(999, location.Y), location.Direction);
            Assert.False(location.Equals(locationCopy));
        }
        [Test]
        public void givenDifferentYWhenEqualsThenFalse() {
            Location locationCopy = new Location(new Point(location.X, 999), location.Direction);
            Assert.False(location.Equals(locationCopy));
        }
        [Test]
        public void givenDifferentDirectionWhenEqualsThenFalse() {
            Location locationCopy = new Location(location.Point, Direction.South);
            Assert.False(location.Equals(locationCopy));
        }
        [Test]
        public void givenSameXYDirectionWhenEqualsThenTrue() {
            Location locationCopy = new Location(location.Point, location.Direction);
            Assert.True(location.Equals(locationCopy));
        }
        [Test]
        public void whenCopyThenDifferentObject() {
            Location copy = location.Copy();
            Assert.AreNotSame(location, copy);
        }
        [Test]
        public void whenCopyThenEquals() {
            Location copy = location.Copy();
            Assert.AreEqual(copy, location);
        }
        [Test]
        public void givenDirectionEAndXEqualsMaxXWhenForwardThen1() {
            location.Direction = Direction.East;
            location.Point.X = max.X;
            location.Forward(max, obstacles);
            Assert.AreEqual(location.X, 1);
        }
        [Test]
        public void givenDirectionWAndXEquals1WhenForwardThenMaxX() {
            location.Direction = Direction.West;
            location.Point.X = 1;
            location.Forward(max, obstacles);
            Assert.AreEqual(location.X, max.X);
        }
        [Test]
        public void givenDirectionNAndYEquals1WhenForwardThenMaxY() {
            location.Direction = Direction.North;
            location.Point.Y = 1;
            location.Forward(max, obstacles);
            Assert.AreEqual(location.Y, max.Y);
        }
        [Test]
        public void givenDirectionSAndYEqualsMaxYWhenForwardThen1() {
            location.Direction = Direction.South;
            location.Point.Y = max.Y;
            location.Forward(max, obstacles);
            Assert.AreEqual(location.Y, 1);
        }
        [Test]
        public void givenObstacleWhenForwardThenReturnFalse() {
            location.Direction = Direction.East;
            obstacles.Add(new Point(x + 1, y));
            Assert.False(location.Forward(max, obstacles));
        }
        [Test]
        public void givenObstacleWhenBackwardThenReturnFalse() {
            location.Direction = Direction.East;
            obstacles.Add(new Point(x - 1, y));
            Assert.False(location.Backward(max, obstacles));
        }
    }
}
