using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class Tile {
        int xPosition;
        int yPosition;
        int value;
        bool isActive;

        public int Value { get { return value; } }
        public bool IsActive {
            get {
                return isActive;
            }
            set {
                isActive = value;
            }
        }

        public Tile(int x, int y, int v = 0) {
            xPosition = x;
            yPosition = y;
            value = v;
        }
    }
}
