using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Forward() {
            Move(FORWARD, new Point(100, 100), new List<Point>());
        }

        public void Forward(Point max) {
            Move(FORWARD, max, new List<Point>());
        }

        public bool Forward(Point max, List<Point> obstacles) {
            return Move(FORWARD, max, obstacles);
        }

        public void Backward() {
            Move(BACKWARD, new Point(100, 100), new List<Point>());
        }

        public void Backward(Point max) {
            Move(BACKWARD, max, new List<Point>());
        }

        public bool Backward(Point max, List<Point> obstacles) {
            return Move(BACKWARD, max, obstacles);
        }

        private bool Move(int fw, Point max, List<Point> obstacles) {
            var x = point.X;
            var y = point.Y;
            switch (Direction) {
                case Direction.North:
                    y = Wrap(Y - fw, max.Y);
                    break;
                case Direction.South:
                    y = Wrap(Y + fw, max.Y);
                    break;
                case Direction.East:
                    x = Wrap(X + fw, max.X);
                    break;
                case Direction.West:
                    x = Wrap(X- fw, max.X);
                    break;
            }
            if (IsObstacle(new Point(x, y), obstacles)) {
                return false;
            }
            else {
                point = new Point(x, y);
                return true;
            }
        }

        private bool IsObstacle(Point point, List<Point> obstacles) {
            return obstacles.Any(obstacle => obstacle.X == point.X && obstacle.Y == point.Y);
        }

        private int Wrap(int point, int maxPoint) {
            if(maxPoint > 0) {
                if (point > maxPoint) {
                    return 1;
                }
                else if (point == 0) {
                    return maxPoint;
                }
            }
            return point;
        }


        public void TurnLeft() {
            Direction = Direction.TurnLeft();
        }

        public void TurnRight() {
            Direction = Direction.TurnRight();
        }

        public Location Copy() {
            return new Location(Point, Direction);
        }


        public override bool Equals(object o) {
            if (this == o)
                return true;
            if (o == null || GetType() != o.GetType())
                return false;
            var location = (Location)o;
            if (X != location.X)
                return false;
            if (Y != location.Y)
                return false;
            if (direction != location.direction)
                return false;
            return true;
        }
    }
}