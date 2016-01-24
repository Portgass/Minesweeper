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

        public void UpdateGraphics(Item item)
        {
            switch (item)
            {
                case Item.Flag:
                    BackColor = Color.FromArgb(244, 67, 54);
                    break;
                case Item.Mine:
                    BackColor = Color.FromArgb(0, 0, 0);
                    break;
                default:
                    BackColor = Color.FromArgb(224, 224, 224);
                    break;
            }
        }

        public void RevealState(bool isRevealed)
        {
            BackColor = isRevealed ? Color.FromArgb(42, 42, 42) : Color.FromArgb(224, 224, 224);
        }

        public void UpdateGraphics(int count)
        {
            if (count == 0)
                return;

            Text = count.ToString();
            BackColor = Color.FromArgb(42, 42, 42);
        }
    }
}
