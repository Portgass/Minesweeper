using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class MenuController {

        private MenuView _menuView;

        private GameDifficulty _difficulty;

        public GameDifficulty Difficulty {
            get { return _difficulty; }
            set { _difficulty = value; }
        }

        private GameMode _gameMode = GameMode.Normal;

        public GameMode GameMode {
            get { return _gameMode; }
            set { _gameMode = value; }
        }

        public MenuController() {
            _menuView = new MenuView();
        }

        void OptionClicked(object sender, System.Windows.Forms.MouseEventArgs e) {
            MenuOption option = (MenuOption)sender;

            if (option.Text == GameDifficulty.Easy.ToString())
                _difficulty = GameDifficulty.Easy;
            else if (option.Text == GameDifficulty.Standard.ToString())
                _difficulty = GameDifficulty.Standard;
            else
                _difficulty = GameDifficulty.Hard;

            _menuView.Window.Close();
            GameController gm = new GameController(_difficulty, _gameMode);
            gm.InitializeGame();
            gm.Update();
        }

        void ExtremeModeSwitch(object sender, System.Windows.Forms.MouseEventArgs e) {
            System.Windows.Forms.CheckBox checkbox = (System.Windows.Forms.CheckBox)sender;

            if (checkbox.Checked)
                _gameMode = GameMode.Extreme;
            else
                _gameMode = GameMode.Normal;

            Console.WriteLine("Changed mode to: " + _gameMode);
        }

        public void StartMenu() {
            _menuView.InitializeMenu();
            foreach (MenuOption option in _menuView.MenuOptions) {
                option.MouseClick += OptionClicked;
            }
            _menuView.ExtremeModeEnabled.MouseClick += ExtremeModeSwitch;
            _menuView.ShowGameMenu();
        }
    }
}
