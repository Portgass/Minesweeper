using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {

    /// <summary>
    /// Represents field on game board.
    /// </summary>
    class FieldView : Button {

        private Coordinates _position;

        public Coordinates Position {
            get { return _position; }
            set {
                _position = value;
                this.Location = new Point(_position.X * 32, _position.Y * 32);
            }
        }

        /// <summary>
        /// Initializes FieldView with base parameters. 
        /// Needs the Field it represents and parent Form.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="parent"></param>
        public FieldView(Field field, Form parent) {
            this.Width = 32;
            this.Height = 32;
            this.Position = field.Position;
            this.Parent = parent;
            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Font = new Font("Arial", 11, FontStyle.Bold);
            this.BackgroundImage = Properties.Resources.field;
        }

        /// <summary>
        /// Changes background and displays number of neighbouring mines.
        /// </summary>
        /// <param name="field"></param>
        public void Reveal(Field field) {
            this.BackgroundImage = Properties.Resources.field_revealed;
            if (field.Items.Contains(FieldItem.Mine))
                this.Text = "*";
            else if (field.NeighbourMineCount > 0)
                this.Text = field.NeighbourMineCount.ToString();
        }

        /// <summary>
        /// Shows(true) or hides(false) flag on field
        /// </summary>
        /// <param name="set"></param>
        public void SetFlag(bool set) {
            if (set)
                this.BackgroundImage = Properties.Resources.field_flag;
            else
                this.BackgroundImage = Properties.Resources.field;
        }
    }
}
