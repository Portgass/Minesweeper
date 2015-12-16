using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // delete

namespace Minesweeper {
    class GameController {

        Board board;

        public void InitializeGame() {
            board = new Board(new Board.Dimension());
            board.InitializeTiles();
            for (int i = 0; i < board.BoardDimension.Width; i++) {
                for (int j = 0; j < board.BoardDimension.Height; j++) {
                }
            }
        }

        public void Update() {
        }
    }
}
