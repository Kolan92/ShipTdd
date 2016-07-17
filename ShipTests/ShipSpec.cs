using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ShipTdd;

namespace ShipTests {
    [TestFixture]
    public class ShipSpec {
        private Location location;
        private Ship ship;
        private Planet planet;
        private int x = 12;
        private int y = 32;

        [SetUp]
        public void SetUp() {
            location = new Location(new Point(x, y), Direction.North);
            var max = new Point(50, 50);
            planet = new Planet(max);
            ship = new Ship(location, planet);
        }

        [Test]
        public void WhenInitiadetThenLoacationIsSet() {
            Assert.AreEqual(ship.Location, location);
        }

        [Test]
        public void WhenMoveForwardThenForward() {
            var expected = location.Copy();
            expected.Forward();
            ship.MoveForward();
            Assert.AreEqual(expected, ship.Location);
        }

        [Test]
        public void WhenMoveBackwarThenBackward() {
            var expected = location.Copy();
            expected.Backward();
            ship.MoveBackward();
            Assert.AreEqual(expected, ship.Location);
        }

        [Test]
        public void WhenTurnLeftThenLeft() {
            var expected = location.Copy();
            expected.TurnLeft();
            ship.TurnLeft();
            Assert.AreEqual(expected, ship.Location);
        }

        [Test]
        public void WhenTurnRightThenRight() {
            var expected = location.Copy();
            expected.TurnRight();
            ship.TurnRight();
            Assert.AreEqual(expected, ship.Location);
        }

        [Test]
        public void WhenReciveComandFThenForward() {
            var expected = location.Copy();
            expected.Forward();
            ship.ReciveCommand("f");
            Assert.AreEqual(expected, ship.Location);
        }

        [Test]
        public void WhenReciveCommandBThenBackward() {
            var expected = location.Copy();
            expected.Backward();
            ship.ReciveCommand("B");
            Assert.AreEqual(expected, ship.Location);
        }

        [Test]
        public void WhenReciveCommandLThenTurnLeft() {
            var expected = location.Copy();
            expected.TurnLeft();
            ship.ReciveCommand("L");
            Assert.AreEqual(expected, ship.Location);
        }

        [Test]
        public void WhenReciveCommandRThenTurnRight() {
            var expected = location.Copy();
            expected.TurnRight();
            ship.ReciveCommand("R");
            Assert.AreEqual(expected, ship.Location);
        }

        [Test]
        public void WhenReciveUnknowCommandThenThrowsArgumentOutOfRangeException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => ship.ReciveCommand("K"));
        }

        [Test]
        public void whenReciveCommandsThenAllExecuted() {
            var expected = location.Copy();
            expected.TurnRight();
            expected.Forward();
            expected.TurnLeft();
            expected.Backward();
            ship.ReciveCommand("RFLB");
            Assert.AreEqual(expected, ship.Location);
        }

        [Test]
        public void WhenInstantiedThenPlanetIsStored() {
            Assert.AreEqual(planet, ship.Planet);
        }

        [Test]
        public void OverpassEastBoundary() {
            location.Direction = Direction.East;
            location.Point.X = planet.Max.X;
            ship.ReciveCommand("F");
            Assert.AreEqual(1, location.X);
        }

        [Test]
        public void OverpassWestBoundary() {
            location.Direction = Direction.East;
            location.Point.X = 1;
            ship.ReciveCommand("B");
            Assert.AreEqual(planet.Max.X, location.X);
        }
    }
}
