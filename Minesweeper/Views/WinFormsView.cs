using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms = System.Windows.Forms;

namespace Minesweeper {
    class WinFormsView {
        private Forms.Form _gameWindow;

        public Forms.Form GameWindow {
            get { return _gameWindow; }
            set { _gameWindow = value; }
        }

        private Forms.Button[,] _tiles;

        public Forms.Button[,] Tiles {
            get { return _tiles; }
            set { _tiles = value; }
        }

        public WinFormsView() {
            _gameWindow = new Forms.Form();
            _gameWindow.Text = "Minesweeper";
        }
        
        public void ShowBoard(Board board) {
            Forms.Application.EnableVisualStyles();
            _tiles = new Forms.Button[board.Dimension.X, board.Dimension.Y];
            for (int i = 0; i < board.Dimension.X; i++) {
                for (int j = 0; j < board.Dimension.X; j++) {
                    Forms.Button tile = new Forms.Button();
                    tile.Width = 25;
                    tile.Height = 25;
                    tile.Location = new System.Drawing.Point(board.TileArray[i, j].Position.X * 25, board.TileArray[i, j].Position.Y * 25);
                    tile.Parent = _gameWindow;
                    _tiles[i,j] = tile;
                }
            }
            Forms.Application.Run(_gameWindow);
        }

    }
}