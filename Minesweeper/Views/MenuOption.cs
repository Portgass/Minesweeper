using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {

    // Base button for menu view.
    class MenuOption : Button {

        private GameDifficulty _gameDifficulty;

        public GameDifficulty GameDifficulty {
            get { return _gameDifficulty; }
            set { _gameDifficulty = value; }
        }

        // Setting base values for button.
        public MenuOption(Form parent) {
            this.Width = 200;
            this.Height = 40;
            this.Parent = parent;
            this.TabStop = false;
            this.BackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.Font = new Font("Arial", 14, FontStyle.Regular);
        }
    }
}
