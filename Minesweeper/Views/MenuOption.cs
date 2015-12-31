using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {
    class MenuOption : Button {

        public MenuOption(Form parent) {
            this.Width = 200;
            this.Height = 50;
            this.Parent = parent;
            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Font = new Font("Arial", 14, FontStyle.Regular);
            this.BackgroundImage = new Bitmap(@"C:\Users\petrd\Source\Repos\Minesweeper\Minesweeper\Images\field.png");
        }
    }
}
