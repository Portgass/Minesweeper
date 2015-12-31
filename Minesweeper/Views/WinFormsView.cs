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
        
        public void InitializeBoard(Board board) {
            _tileObjects = new Forms.Button[board.Dimension.X, board.Dimension.Y];

            for (int i = 0; i < board.Dimension.X; i++) {
                for (int j = 0; j < board.Dimension.Y; j++) {
                    Tile tile = board.Tiles[i, j];
                    TileView tileView = new TileView(tile.Position, tile.NeighbourMineCount.ToString(), tile.Objects, _gameWindow);
                    _tileObjects[i,j] = tileView;
                }
            }
        }

        public void ShowBoard(Board board) {
            Forms.Application.EnableVisualStyles();
            SetWindowSize(board.Dimension);
            Forms.Application.Run(_gameWindow);
        }


        /// <summary>
        /// Needs new controller for game menu
        /// </summary>
        public void SetBoardDimensions() {
            Forms.Application.EnableVisualStyles();
            SetWindowSize(new Coordinates(300, 300));
            Forms.TextBox text = new Forms.TextBox();
            text.Width = 200;
            text.Height = 200;
            text.Location = new Drawing.Point(300, 300);
            text.Text = "asdkjfbuikdsgbfiudshi";
            text.BackColor = Drawing.Color.Black;
            _gameWindow.Controls.Add(text);
            Forms.Application.Run(_gameWindow);
        }

    }
}