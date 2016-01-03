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

            _difficulty = option.GameDifficulty;

            _menuView.Window.Close();

            Console.WriteLine("Started " + _difficulty.ToString() + " game on " + _gameMode + " mode.");

            GameController gm = new GameController(_difficulty, _gameMode);
            gm.InitializeGame();
            gm.Update();
        }

        void ExtremeModeSwitch(object sender, System.Windows.Forms.MouseEventArgs e) {
            MenuOption option = (MenuOption)sender;

            if (_gameMode == GameMode.Normal) {
                option.BackgroundImage = Properties.Resources.option_extreme_selected;
                _gameMode = GameMode.Extreme;
            }
            else {
                option.BackgroundImage = Properties.Resources.option_extreme;
                _gameMode = GameMode.Normal;
            }

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
