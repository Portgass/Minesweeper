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
            _menuView.CloseWindow();
        }

        public void StartMenu() {
            _menuView.ShowGameMenu();
            _menuView.MenuOptions.ForEach(option => option.MouseClick += OptionClicked);
        }
    }
}
