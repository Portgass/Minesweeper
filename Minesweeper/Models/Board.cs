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
        
        private Tile[,] tiles;

        public Tile[,] Tiles {
            get { return tiles; }
            set { tiles = value; }
        }

        private List<Tile> _bombs;

        public List<Tile> Bombs {
            get { return _bombs; }
            set { _bombs = value; }
        }

        public Board(Coordinates dimension) {
            _dimension = dimension;
            tiles = new Tile[dimension.X, dimension.Y];
            Console.WriteLine("Created board with dimensions: " + dimension.X + ", " + dimension.Y);
        }

        public void InitializeTiles() {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    tiles[i, j] = new Tile(new Coordinates(i, j));
                }
            }
        }

        /// <summary>
        /// New parameter for BombArray
        /// New function to generate random nums
        /// </summary>
        public void PlantBombs() {
            for (int i = 0; i < 10;i++) {

            }
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    tiles[i, j].Type = TileType.Bomb;
                }
            }
        }
    }
}
