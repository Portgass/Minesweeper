using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Minesweeper.Models;

namespace Minesweeper.Views {
    
    public class TileView : Button {

        private readonly Color _tileColor = Color.FromArgb(224, 224, 224);
        private Color _highlightTileColor = Color.FromArgb(158, 158, 158);
        private readonly Color _highlightNeighbourColor = Color.FromArgb(189, 189, 189);


        public TileView(Coordinates position) {
            Size = new Size(24, 24);
            Location = new Point(position.X * 24, position.Y * 24);
            TabStop = false;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = _tileColor;
            Font = new Font("pixelmix", 12, FontStyle.Regular);
        }

        public void RevealTileContent(int mineCount)
        {
            BackColor = Color.FromArgb(42, 42, 42);

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

        public void DisplayFlag(bool display)
        {
            BackColor = display ? Color.FromArgb(244, 67, 54) : _tileColor;
        }

        public void HighlightTile()
        {
            if (BackColor == _tileColor || BackColor == _highlightTileColor)
                BackColor = BackColor == _tileColor ? _highlightTileColor : _tileColor;
        }

        public void HighlightNeighbour()
        {
            if (BackColor == _tileColor || BackColor == _highlightNeighbourColor)
                BackColor = BackColor == _tileColor ? _highlightNeighbourColor : _tileColor;
        }

        public void DisplayMine()
        {
            BackColor = Color.FromArgb(0, 0, 0);
        }
    }
}
