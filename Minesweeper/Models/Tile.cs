using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TileType { Empty, Mine };

namespace Minesweeper {
    class Tile {

        private Coordinates _position;

        public Coordinates Position {
            get { return _position; }
            set { _position = value; }
        }

        private TileType _type = TileType.Empty;

        public TileType Type {
            get { return _type; }
            set {
                _type = value;
                Console.WriteLine("Set Tile[" + _position.X + ", " + _position.Y + "] TileType: " + value);
            }
        }

        public Tile(Coordinates position) {
            _position = position;
            Console.WriteLine("Created tile with position: " + position.X + ", " + position.Y);
        }
    }
}
