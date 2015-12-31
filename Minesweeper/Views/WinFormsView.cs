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

        public WinFormsView() {
            _gameWindow = new Form();
            _gameWindow.Text = "Minesweeper";
        }

        void SetWindowSize(Coordinates size) {
            _gameWindow.ClientSize = new Size(size.X * 25, size.Y * 25 + 25);
        }

        public void ShowBoard(Board board) {
            Application.EnableVisualStyles();
            SetWindowSize(board.Dimension);
            Application.Run(_gameWindow);
        }

    }
}