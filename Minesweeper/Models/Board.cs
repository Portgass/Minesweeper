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
        
        private Tile[,] _tiles;

        public Tile[,] Tiles {
            get { return _tiles; }
            set { _tiles = value; }
        }

        private List<Tile> _mines = new List<Tile>();

        public List<Tile> Mines {
            get { return _mines; }
            set { _mines = value; }
        }

        public Board(Coordinates dimension) {
            _dimension = dimension;
            _tiles = new Tile[dimension.X, dimension.Y];
            Console.WriteLine("Created board with dimensions: " + dimension.X + ", " + dimension.Y);
        }

        public void InitializeTiles() {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    _tiles[i, j] = new Tile(new Coordinates(i, j));
                }
            }
        }
        
        public void PlantMines() {
            int mineCount = 10;
            int maxRnd = (_dimension.X * _dimension.Y) - 1;
            List<int> mineCoords = new List<int>();
            Random rnd = new Random();

            Console.WriteLine("Generating " + mineCount + " random numbers between 0 and " + maxRnd);

            for (int i = 0; i < mineCount; i++) {
                int rndNum;
                do {
                    rndNum = rnd.Next(maxRnd);
                } while (mineCoords.Contains(rndNum));
                mineCoords.Add(rndNum);
                Console.WriteLine("Random number " + (i + 1) + ": " + rndNum);
            }

            int boardPosition = 0;
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    if (mineCoords.Contains(boardPosition)) {
                        _tiles[i, j].Type = TileType.Mine;
                        _mines.Add(_tiles[i, j]);
                    }
                    boardPosition += 1;
                }
            }
        }
    }
}
