using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {
    class MenuOption : Button {

        private GameDifficulty _gamemDifficulty;

        public GameDifficulty GameDifficulty {
            get { return _gamemDifficulty; }
            set { _gamemDifficulty = value; }
        }

        public MenuOption(Form parent) {
            this.Width = 200;
            this.Height = 40;
            this.Parent = parent;
            this.TabStop = false;
            this.BackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.Font = new Font("Arial", 14, FontStyle.Regular);
            this.BackgroundImage = Properties.Resources.option;
        }
    }
}
