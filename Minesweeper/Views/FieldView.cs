using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {
    class FieldView : System.Windows.Forms.Button {

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
        }

        public void Reveal(Field field) {
            if (field.Items.Contains(FieldItem.Mine))
                this.Text = "*";
            else
                this.Text = field.NeighbourMineCount.ToString();
        }

        public void SetFlag(bool set) {
            if (set)
                this.Text = "!";
            else
                this.Text = "";
        }
    }
}
