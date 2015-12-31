using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TileObject { Mine };

namespace Minesweeper {
    class Tile {

        private Coordinates _position;

        public Coordinates Position {
            get { return _position; }
            set { _position = value; }
        }

        private List<TileObject> _objects;

        public List<TileObject> Objects
        {
            get { return _objects; }
            set { _objects = value; }
        }

        private int _neighbourMineCount;

        public int NeighbourMineCount {
            get { return _neighbourMineCount; }
            set { _neighbourMineCount = value; }
        }

        public Tile(Coordinates position) {
            _position = position;
            _objects = new List<TileObject>();
            Console.WriteLine("Created tile with position: " + position.X + ", " + position.Y);
        }
    }
}
