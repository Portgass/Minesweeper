using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing = System.Drawing;
using Forms = System.Windows.Forms;

namespace Minesweeper {
    class WinFormsView {
        private Forms.Form _gameWindow;

        public Forms.Form GameWindow {
            get { return _gameWindow; }
            set { _gameWindow = value; }
        }

        private Forms.Button[,] _tileObjects;

        public Forms.Button[,] TileObjects {
            get { return _tileObjects; }
            set { _tileObjects = value; }
        }

        public WinFormsView() {
            _gameWindow = new Forms.Form();
            _gameWindow.Text = "Minesweeper";
        }

        void SetWindowSize(Coordinates size) {
            _gameWindow.ClientSize = new Drawing.Size(size.X * 25, size.Y * 25);
        }
        
        public void ShowBoard(Board board) {
            Forms.Application.EnableVisualStyles();
            SetWindowSize(board.Dimension);
            _tileObjects = new Forms.Button[board.Dimension.X, board.Dimension.Y];
            for (int i = 0; i < board.Dimension.X; i++) {
                for (int j = 0; j < board.Dimension.Y; j++) {
                    Forms.Button tile = new Forms.Button();
                    tile.Width = 25;
                    tile.Height = 25;
                    if (board.Tiles[i,j].Type == TileType.Mine) {
                        tile.Text = "*";
                    }
                    tile.Location = new Drawing.Point(board.Tiles[i, j].Position.X * 25, board.Tiles[i, j].Position.Y * 25);
                    tile.Parent = _gameWindow;
                    _tileObjects[i,j] = tile;
                }
            }
            Forms.Application.Run(_gameWindow);
        }

    }
}