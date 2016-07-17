using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ShipTdd;
using ShipTests;

namespace ShipTests {

    [TestFixture]
    public class PointSpec {
        private Point point;
        private const int x = 12;
        private const int y = 10;

        [SetUp]
        public void SetUp() {
            point = new Point(x,y);
        }

        [Test]
        public void WhenInstantiatedThenXIsSet() {
            Assert.AreEqual(point.X, x);
        }

        [Test]
        public void WhenInstantiatedThenYIsSet() {
            Assert.AreEqual(point.Y, y);
        }
    }
}
