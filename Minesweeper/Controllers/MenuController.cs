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

        /// <summary>
        /// Initializes controller with corresponding view.
        /// </summary>
        public MenuController() {
            _menuView = new MenuView();
        }


        /// <summary>
        /// Closes menu, creates new Game Controller and starts game in set game mode with set difficulty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OptionClicked(object sender, System.Windows.Forms.MouseEventArgs e) {
            MenuOption option = (MenuOption)sender;

            _difficulty = option.GameDifficulty;

            _menuView.Window.FormClosed -= _menuView.ExitApp;
            _menuView.Window.Close();

            // Console.WriteLine("Started " + _difficulty.ToString() + " game on " + _gameMode + " mode.");

            GameController gm = new GameController(_difficulty, _gameMode);
            gm.InitializeGame();
            gm.Start();
        }

        /// <summary>
        /// Enables(disables) extreme game mode bases on previous state and updates view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            // Console.WriteLine("Changed mode to: " + _gameMode);
        }

        /// <summary>
        /// Initializes and shows game menu and adds callbacks for menu buttons.
        /// </summary>
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
