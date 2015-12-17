using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class Tile {

        private Coordinates _position;

        public Coordinates Position {
            get { return _position; }
            set { _position = value; }
        }

        public enum TileType { Empty, Bomb };

        private TileType _type = TileType.Empty;

        public TileType Type {
            get { return _type; }
            set {
                _type = value;
                Console.WriteLine("Set TileType: " + value);
            }
        }

        public Tile(Coordinates position) {
            _position = position;
            Console.WriteLine("Created tile with position: " + position.X + ", " + position.Y);
        }
    }
}
