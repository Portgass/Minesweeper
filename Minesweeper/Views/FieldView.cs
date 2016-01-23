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
                this.Location = new Point(_position.X * 24, _position.Y * 24);
            }
        }

        /// <summary>
        /// Initializes FieldView with base parameters. 
        /// Needs the Field it represents and parent Form.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="parent"></param>
        public FieldView(Field field, Form parent) {
            this.Width = 24;
            this.Height = 24;
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
            this.BackgroundImage = null;
            switch (field.NeighbourMineCount)
            {
                case 1:
                    this.BackgroundImage = Properties.Resources._1;
                    break;
                case 2:
                    this.BackgroundImage = Properties.Resources._2;
                    break;
                case 3:
                    this.BackgroundImage = Properties.Resources._3;
                    break;
                case 4:
                    this.BackgroundImage = Properties.Resources._4;
                    break;
                case 5:
                    this.BackgroundImage = Properties.Resources._5;
                    break;
                case 6:
                    this.BackgroundImage = Properties.Resources._6;
                    break;
                case 7:
                    this.BackgroundImage = Properties.Resources._7;
                    break;
                case 8:
                    this.BackgroundImage = Properties.Resources._8;
                    break;
                case 9:
                    this.BackgroundImage = Properties.Resources._9;
                    break;
                default:
                    this.BackgroundImage = null;
                    break;
            }
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
