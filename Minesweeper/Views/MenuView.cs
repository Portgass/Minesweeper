using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {
    class MenuView : View {

        private List<MenuOption> _menuOptions = new List<MenuOption>();

        /// <summary>
        /// Should contain all menu options.
        /// </summary>
        public List<MenuOption> MenuOptions {
            get { return _menuOptions; }
            set { _menuOptions = value; }
        }

        private MenuOption _extremeModeEnabled;

        /// <summary>
        /// Contains extreme mode button.
        /// If the game is going to increase the number of modes, move all the modes to MenuOption list.
        /// </summary>
        public MenuOption ExtremeModeEnabled {
            get { return _extremeModeEnabled; }
            set { _extremeModeEnabled = value; }
        }


        /// <summary>
        /// Initializes menu window.
        /// All UI elements are set and placed.
        /// </summary>
        public void InitializeMenu() {
            Window.Size = new Size(600, 600);
            Window.BackgroundImage = Properties.Resources.bcg;

            MenuOption easyGameOption = new MenuOption(Window);
            MenuOption standardGameOption = new MenuOption(Window);
            MenuOption hardGameOption = new MenuOption(Window);
            _extremeModeEnabled = new MenuOption(Window);

            // Set difficulty
            easyGameOption.GameDifficulty = GameDifficulty.Easy;
            standardGameOption.GameDifficulty = GameDifficulty.Standard;
            hardGameOption.GameDifficulty = GameDifficulty.Hard;

            // Add options to list.
            _menuOptions.Add(easyGameOption);
            _menuOptions.Add(standardGameOption);
            _menuOptions.Add(hardGameOption);

            // Set backgrounds
            easyGameOption.BackgroundImage = Properties.Resources.option_easy;
            standardGameOption.BackgroundImage = Properties.Resources.option_standard;
            hardGameOption.BackgroundImage = Properties.Resources.option_hard;
            _extremeModeEnabled.BackgroundImage = Properties.Resources.option_extreme;

            // Positioning options to the middle of screen under game logo.
            easyGameOption.Top = 250;
            standardGameOption.Top = 310;
            hardGameOption.Top = 370;

            foreach (MenuOption option in _menuOptions) {
                option.Left = (Window.ClientSize.Width - option.Size.Width) / 2;
            }

            _extremeModeEnabled.Location = new Point(((Window.ClientSize.Width - _extremeModeEnabled.Size.Width) / 2), 430);
        }

        /// <summary>
        /// Starts application and shows menu.
        /// </summary>
        public void ShowGameMenu() {
            Application.EnableVisualStyles();
            Window.Show();
            Application.Run();
        }
    }
}
