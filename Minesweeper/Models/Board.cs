using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class Board {

        public class Dimension {
            int _width = 10;
            int _height = 10;

            public int Width { get; set; }
            public int Height { get; set; }

            public Dimension() { }

            public Dimension(int width, int height) {
                _width = width;
                _height = height;
            }
        }

        public Dimension BoardDimension { get; set; }

        Tile[,] tileArray;

        public Tile[,] TileArray { get; }

        public Board(Dimension dimension) {
            BoardDimension = dimension;
        }

        public void InitializeTiles() {
            for (int i = 0; i < BoardDimension.Width; i++) {
                for (int j = 0; j < BoardDimension.Height; j++) {
                    tileArray[i, j] = new Tile(new Tile.Position(i, j));
                }
            }
        }
    }
}
