using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class Cursor {
        int xPosition;
        int yPosition;

        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public Cursor(int x = 1, int y = 1) {
            xPosition = x;
            yPosition = y;
        }
        
    }
}
