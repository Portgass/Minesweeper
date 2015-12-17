using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class Board {

        private Coordinates _dimension;

        public Coordinates Dimension {
            get { return _dimension; }
            set { _dimension = value; }
        }
        
        private Tile[,] _tileArray;

        public Tile[,] TileArray {
            get { return _tileArray; }
            set { _tileArray = value; }
        }
        
        public Board(Coordinates dimension) {
            _dimension = dimension;
            _tileArray = new Tile[dimension.X, dimension.Y];
            Console.WriteLine("Created board with dimensions: " + dimension.X + ", " + dimension.Y);
        }

        public void InitializeTiles() {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    _tileArray[i, j] = new Tile(new Coordinates(i, j));
                }
            }
        }

        /// <summary>
        /// New parameter for BombArray
        /// New function to generate random nums
        /// </summary>
        public void PlantBombs() {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    _tileArray[i, j].Type = Tile.TileType.Bomb;
                }
            }
        }
    }
}
