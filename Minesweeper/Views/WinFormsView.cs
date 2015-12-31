using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {
    class WinFormsView {
        private Form _gameWindow;

        public Form GameWindow {
            get { return _gameWindow; }
            set { _gameWindow = value; }
        }

        private Button[,] _tileObjects;

        public Button[,] TileObjects {
            get { return _tileObjects; }
            set { _tileObjects = value; }
        }

        public WinFormsView() {
            _gameWindow = new Form();
            _gameWindow.Text = "Minesweeper";
        }

        void SetWindowSize(Coordinates size) {
            _gameWindow.ClientSize = new Size(size.X * 25, size.Y * 25);
        }
        
        public void InitializeBoard(Board board) {
            _tileObjects = new Button[board.Dimension.X, board.Dimension.Y];

            for (int i = 0; i < board.Dimension.X; i++) {
                for (int j = 0; j < board.Dimension.Y; j++) {
                    Tile tile = board.Tiles[i, j];
                    TileView tileView = new TileView(tile.Position, tile.NeighbourMineCount.ToString(), tile.Objects, _gameWindow);
                }
            }
        }

        public void ShowBoard(Board board) {
            Application.EnableVisualStyles();
            SetWindowSize(board.Dimension);
            Application.Run(_gameWindow);
        }


        /// <summary>
        /// Needs new controller for game menu
        /// </summary>
        public void SetBoardDimensions() {
            Application.EnableVisualStyles();
            SetWindowSize(new Coordinates(300, 300));
            TextBox text = new TextBox();
            text.Width = 200;
            text.Height = 200;
            text.Location = new Point(300, 300);
            text.Text = "asdkjfbuikdsgbfiudshi";
            text.BackColor = Color.Black;
            _gameWindow.Controls.Add(text);
            Application.Run(_gameWindow);
        }

    }
}