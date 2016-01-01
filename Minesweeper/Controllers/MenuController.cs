using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum GameDifficulty { Easy, Standart, Hard };

namespace Minesweeper {
    class MenuController {

        private MenuView _menuView;

        private GameDifficulty _difficulty;

        public GameDifficulty Difficulty {
            get { return _difficulty; }
            set { _difficulty = value; }
        }

        private bool _extremeModeEnabled;

        public bool ExtremeModeEnabled {
            get { return _extremeModeEnabled; }
            set { _extremeModeEnabled = value; }
        }

        public MenuController() {
            _menuView = new MenuView();
        }

        void OptionClicked(object sender, System.Windows.Forms.MouseEventArgs e) {
            MenuOption option = (MenuOption)sender;

            if (option.Text == "Easy")
                _difficulty = GameDifficulty.Easy;
            else if (option.Text == "Standart")
                _difficulty = GameDifficulty.Standart;
            else
                _difficulty = GameDifficulty.Hard;

            _menuView.Window.Close();
            GameController gm = new GameController(_difficulty);
            gm.InitializeGame();
            gm.Update();
        }

        public void StartMenu() {
            _menuView.InitializeMenu();
            foreach (MenuOption option in _menuView.MenuOptions) {
                option.MouseClick += OptionClicked;
            }
            _menuView.ShowGameMenu();
        }
    }
}
