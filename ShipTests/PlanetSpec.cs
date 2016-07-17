using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using ShipTdd;

namespace ShipTests {
    [TestFixture]
    public class PlanetSpec {

        private Planet planet;
        private Point max = new Point(50,50);
        private IList<Point> obstacles;

        [SetUp]
        public void SetUp() {
            obstacles = new List<Point>() {
                new Point(12, 13),
                new Point(16, 32)
            };

            planet = new Planet(max, obstacles);
        }

        [Test]
        public void WhenInstantiatedThenMaxIsSet() {
            Assert.AreEqual(planet.Max, max);
        }

        [Test]
        public void WhenInstantiatedThenObstaclesAreSet() {
            Assert.AreEqual(planet.Obstacles, obstacles);
        }

    }
}
