using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {

    /// <summary>
    /// Defines the units in which are all game objects represented.
    /// </summary>
    class Coordinates {

        private int _x;

        public int X {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;

        public int Y {
            get { return _y; }
            set { _y = value; }
        }

        public Coordinates(int x, int y) {
            _x = x;
            _y = y;
            // Console.WriteLine("New coordinates: " + x + ", " + y);
        }

        /// <summary>
        /// Helps with printing out the coordinates.
        /// </summary>
        public string GetCoordinates() {
            return _x + ", " + _y;
        }
    }
}