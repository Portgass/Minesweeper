using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {
    class FieldView : Button {

        private Coordinates _position;

        public Coordinates Position {
            get { return _position; }
            set {
                _position = value;
                this.Location = new Point(_position.X * 25, _position.Y * 25);
            }
        }

        public FieldView(Field field, Form parent) {
            this.Width = 25;
            this.Height = 25;
            this.Position = field.Position;
            this.Parent = parent;
            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Font = new Font("Arial", 11, FontStyle.Bold);
            this.BackgroundImage = new Bitmap(@"C:\Users\petrd\Source\Repos\Minesweeper\Minesweeper\Images\field.png");
        }

        public void Reveal(Field field) {
            this.BackgroundImage = new Bitmap(@"C:\Users\petrd\Source\Repos\Minesweeper\Minesweeper\Images\field_revealed.png");
            if (field.Items.Contains(FieldItem.Mine))
                this.Text = "*";
            else if (field.NeighbourMineCount > 0)
                this.Text = field.NeighbourMineCount.ToString();
        }

        public void SetFlag(bool set) {
            if (set)
                this.BackgroundImage = new Bitmap(@"C:\Users\petrd\Source\Repos\Minesweeper\Minesweeper\Images\field_flag.png");
            else
                this.BackgroundImage = new Bitmap(@"C:\Users\petrd\Source\Repos\Minesweeper\Minesweeper\Images\field.png");
        }
    }
}
