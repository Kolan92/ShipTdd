using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTdd {
    public class Planet {
        public Point Max { get; private set; }
        public IList<Point> Obstacles { get; private set; }
        public Planet(Point max, IList<Point> obstacles) {
            Max = max;
            Obstacles = obstacles;
        }

        public Planet(Point max) {
            Max = max;
        }
    }
}
