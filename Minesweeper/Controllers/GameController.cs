using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class GameController {
        Board board;
        Cursor cursor;
        ConsoleView console = new ConsoleView();

        public void InitializeGame() {
            int boardWidth = console.GetProperty("width");
            int boardHeight = console.GetProperty("height");
            board = new Board(boardWidth, boardHeight);
            cursor = new Cursor();
            board.InitializeTiles();
            console.ShowBoard(board, cursor);
        }

        public void Update() {
            while (true) {
                console.ShowBoard(board, cursor);
                // Reads key 2 times instead of 1
                // Needs complete rework
                cursor.MoveCursor(console.CursorMovement("x"), console.CursorMovement("y"));
            }
        }
    }
}
