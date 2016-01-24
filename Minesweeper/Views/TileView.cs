using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Minesweeper.Models;

namespace Minesweeper.Views {
    
    public class TileView : Button {

        private readonly Color _tileColor = Color.FromArgb(224, 224, 224);
        private readonly Color _highlightTileColor = Color.FromArgb(214, 214, 214);

        private readonly Color _tileRevealColor = Color.FromArgb(42, 42, 42);
        private readonly Color _highlightTileRevealColor = Color.FromArgb(38, 38, 38);

        private readonly Color _tileFlagColor = Color.FromArgb(244, 67, 54);
        private readonly Color _highlightTileFlagColor = Color.FromArgb(229, 57, 53);

        public TileView(Coordinates position) {
            Size = new Size(24, 24);
            Location = new Point(position.X * 24, position.Y * 24);
            TabStop = false;
            BackColor = _tileColor;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = BackColor;
            FlatAppearance.MouseDownBackColor = BackColor;
            BackColorChanged += (s, e) => {
                FlatAppearance.MouseOverBackColor = BackColor;
                FlatAppearance.MouseDownBackColor = BackColor;
            };
            Font = new Font("pixelmix", 12, FontStyle.Regular);
        }

        public void RevealTileContent(int mineCount)
        {
            BackColor = _tileRevealColor;

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
            BackColor = display ? _tileFlagColor : _tileColor;
        }

        public void HighlightTile()
        {
            if (BackColor == _tileColor || BackColor == _highlightTileColor)
                BackColor = BackColor == _tileColor ? _highlightTileColor : _tileColor;
            else if (BackColor == _tileRevealColor || BackColor == _highlightTileRevealColor)
                    BackColor = BackColor == _tileRevealColor ? _highlightTileRevealColor : _tileRevealColor;
            else if (BackColor == _tileFlagColor || BackColor == _highlightTileFlagColor)
                BackColor = BackColor == _tileFlagColor ? _highlightTileFlagColor : _tileFlagColor;
        }

        public void DisplayMine()
        {
            BackColor = Color.FromArgb(0, 0, 0);
        }
    }
}
