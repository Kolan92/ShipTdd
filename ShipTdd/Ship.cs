using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTdd {
    public class Ship {
        public Location Location { get { return location; } }
        public Planet Planet { get { return planet; } }

        private Location location;
        private Planet planet;

        public Ship(Location location, Planet planet) {
            this.location = location;
            this.planet = planet;
        }

        public void MoveForward() {
            location.Forward(planet.Max);
        }

        public void MoveBackward() {
            location.Backward(planet.Max);
        }

        public void TurnLeft() {
            location.TurnLeft();
        }

        public void TurnRight() {
            location.TurnRight();
        }

        public void ReciveCommand(string command) {
            foreach (var c in command.ToUpper().ToCharArray()) {
                switch (c) {
                    case 'F':
                        MoveForward();
                        break;
                    case 'B':
                        MoveBackward();
                        break;
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
