using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {
    class GameView : View {

        void SetWindowSize(Coordinates size) {
            Window.ClientSize = new Size(size.X * 25, size.Y * 25 + 25);
        }

        public void ShowBoard(Board board) {
            SetWindowSize(board.Dimension);
            Window.Show();
        }
    }
}