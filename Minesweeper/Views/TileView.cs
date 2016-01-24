using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Minesweeper.Models;

namespace Minesweeper.Views {
    
    public class TileView : Button {

        public TileView(Coordinates position) {
            Size = new Size(24, 24);
            Location = new Point(position.X * 24, position.Y * 24);
            TabStop = false;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(224, 224, 224);
            Font = new Font("pixelmix", 12, FontStyle.Regular);
        }

        public void DisplayFlag(bool display)
        {
            BackColor = display ? Color.FromArgb(244, 67, 54) : Color.FromArgb(224, 224, 224);
        }

        public void DisplayMine()
        {
            BackColor = Color.FromArgb(0, 0, 0);
        }

        public void DisplayNeighbourContent(int mineCount)
        {
            Text = mineCount.ToString();

            if (mineCount == 0)
                Text = "";

            switch (mineCount)
            {
                case 1:
                    ForeColor = Color.FromArgb(76, 175, 80);
                    break;
                case 2:
                    ForeColor = Color.FromArgb(139, 195, 74);
                    break;
                case 3:
                    ForeColor = Color.FromArgb(205, 220, 57);
                    break;
                case 4:
                    ForeColor = Color.FromArgb(255, 235, 59);
                    break;
                case 5:
                    ForeColor = Color.FromArgb(255, 193, 7);
                    break;
                case 6:
                    ForeColor = Color.FromArgb(255, 152, 0);
                    break;
                case 7:
                    ForeColor = Color.FromArgb(255, 87, 34);
                    break;
                case 8:
                    ForeColor = Color.FromArgb(191, 54, 12);
                    break;

            }
        }

        public void RevealState(bool isRevealed)
        {
            BackColor = isRevealed ? Color.FromArgb(42, 42, 42) : Color.FromArgb(224, 224, 224);

            if (isRevealed)
                Text = "";
        }
    }
}
