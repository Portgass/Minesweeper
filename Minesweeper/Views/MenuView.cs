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

        public void InitializeMenu() {
            Window.Size = new Size(600, 600);
            Window.BackgroundImage = new Bitmap(@"C:\Users\petrd\Source\Repos\Minesweeper\Minesweeper\Images\bcg.png");

            MenuOption easyGameOption = new MenuOption(Window);
            MenuOption standartGameOption = new MenuOption(Window);
            MenuOption hardGameOption = new MenuOption(Window);

            _menuOptions.Add(easyGameOption);
            _menuOptions.Add(standartGameOption);
            _menuOptions.Add(hardGameOption);

            easyGameOption.Top = 250;
            standartGameOption.Top = 325;
            hardGameOption.Top = 400;

            easyGameOption.Text = "Easy";
            standartGameOption.Text = "Standart";
            hardGameOption.Text = "Hard";

            foreach (MenuOption option in _menuOptions) {
                option.Left = (Window.ClientSize.Width - option.Size.Width) / 2;
            }
        }

        public void ShowGameMenu() {
            Application.EnableVisualStyles();
            Window.Show();
            Application.Run();
        }
    }
}
