using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class GameController {

        private Board _board;

        public Board GameBoard {
            get { return _board; }
            set { _board = value; }
        }

        private WinFormsView _gameView;

        public WinFormsView GameView {
            get { return _gameView; }
            set { _gameView = value; }
        }

        public GameController() {
            _gameView = new WinFormsView();
        }

        public void InitializeGame() {
            _board = new Board(new Coordinates(10, 10));
            _board.InitializeTiles();
            _gameView.ShowBoard(_board);
        }

        public void Update() {
        }
    }
}
