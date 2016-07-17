using System;
using System.Collections.Generic;

namespace ShipTdd {
    public class Location {
        public int X { get { return point.X; } }
        public int Y { get { return point.Y; } }
        public Point Point { get { return point; } }

        public Direction Direction {
            get { return direction; }
            set { direction = value; }
        }

        private Direction direction;
        private Point point;

        private static int FORWARD = 1;
        private static int BACKWARD = -1;

        public Location(Point point, Direction direction) {
            this.point = point;
            this.direction = direction;
        }

        public bool Forward(Point max, List<Point> obstacles) {
            throw new System.NotImplementedException();
        }

        public bool Backward(Point max, List<Point> obstacles) {
            throw new NotImplementedException();
        }

        public void TurnLeft() {
            throw new NotImplementedException();
        }

        public void TurnRight() {
            throw new NotImplementedException();
        }

        public Location Copy() {
            throw new NotImplementedException();
        }
    }
}