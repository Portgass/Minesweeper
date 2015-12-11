using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    enum GameAction { MoveLeft, MoveRight, MoveUp, MoveDown };
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
        }

        public void MoveCursor(GameAction movement) {
            switch (movement) {
                case GameAction.MoveLeft:
                    cursor.XPosition -= 1;
                    break;
                case GameAction.MoveRight:
                    cursor.XPosition += 1;
                    break;
                case GameAction.MoveUp:
                    cursor.YPosition -= 1;
                    break;
                case GameAction.MoveDown:
                    cursor.YPosition += 1;
                    break;
            }
        }

        public void ChooseAction() {
            GameAction action = console.GetActionKey();
            MoveCursor(action);
        }

        public void Update() {
            while (true) {
                console.ShowBoard(board, cursor);
                ChooseAction();
            }
        }
    }
}
