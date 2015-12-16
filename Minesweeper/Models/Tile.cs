using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class Tile {

        public class Position {
            int _x;
            int _y;

            public int X { get; set; }
            public int Y { get; set; }

            public Position(int x, int y) {
                _x = x;
                _y = y;
            }
        }

        public Position TilePosition { get; set; }

        public enum TileType { Empty, Bomb };
        
        public Tile(Position position) {
            TilePosition = position;
        }
    }
}
