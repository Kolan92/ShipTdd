using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace ShipTdd {
    public enum Direction {
        [Description("N")]
        North  = 0,
        [Description("E")]
        East   = 1,
        [Description("S")]
        South  = 2,
        [Description("W")]
        West   = 3,
        None   = 4
    }

    public static class DirectionExtension {
        public static Direction GetFromShortName<T>(string name) where T : struct, IConvertible {
            var type = typeof(T);
            if (!type.IsEnum) 
                throw new ArgumentException("T must be an enumerated type");

            foreach (var field in type.GetFields()) {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute == null) continue;
                if (string.Equals(attribute.Description, name, StringComparison.InvariantCultureIgnoreCase))
                    return (Direction) field.GetRawConstantValue();
            }
            return Direction.None;
        }

        public static Direction TurnLeft(this Enum direction) {
            var currentDirection = (Direction) direction;
            return (Direction)(((int)currentDirection + 3) % 4);

        }

        public static Direction TurnRight(this Enum direction) {
            var currentDirection = (Direction)direction;
            return (Direction)(((int)currentDirection + 1) % 4);
        }
    }
}