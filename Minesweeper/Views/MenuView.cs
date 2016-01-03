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

        public List<MenuOption> MenuOptions {
            get { return _menuOptions; }
            set { _menuOptions = value; }
        }

        private CheckBox _extremeModeEnabled;

        public CheckBox ExtremeModeEnabled {
            get { return _extremeModeEnabled; }
            set { _extremeModeEnabled = value; }
        }

        public void InitializeMenu() {
            Window.Size = new Size(600, 600);
            Window.BackgroundImage = Properties.Resources.bcg;

            MenuOption easyGameOption = new MenuOption(Window);
            MenuOption standardGameOption = new MenuOption(Window);
            MenuOption hardGameOption = new MenuOption(Window);

            _menuOptions.Add(easyGameOption);
            _menuOptions.Add(standardGameOption);
            _menuOptions.Add(hardGameOption);

            easyGameOption.Top = 250;
            standardGameOption.Top = 325;
            hardGameOption.Top = 400;

            easyGameOption.Text = GameDifficulty.Easy.ToString();
            standardGameOption.Text = GameDifficulty.Standard.ToString();
            hardGameOption.Text = GameDifficulty.Hard.ToString();

            foreach (MenuOption option in _menuOptions) {
                option.Left = (Window.ClientSize.Width - option.Size.Width) / 2;
            }

            _extremeModeEnabled = new CheckBox();
            _extremeModeEnabled.Text = "Enable Extreme Mode";
            _extremeModeEnabled.Parent = Window;
        }

        public void ShowGameMenu() {
            Application.EnableVisualStyles();
            Window.Show();
            Application.Run();
        }
    }
}
