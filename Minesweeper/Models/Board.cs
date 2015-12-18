using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class Board {
        int width;
        int height;
        Tile[,] tileArray;

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public Tile[,] TileArray { get { return tileArray; } }

        public Board(int w, int h) {
            width = w;
            height = h;
            tileArray = new Tile[w, h];
        }

        public void InitializeTiles() {
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    tileArray[i, j] = new Tile(i, j);
                }
            }
        }
    }
}
