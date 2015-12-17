using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class GameController {

        Board board;

        public void InitializeGame() {
            board = new Board(new Coordinates(10, 10));
            board.InitializeTiles();
        }

        public void Update() {
        }
    }
}
