using System.Collections.Generic;
using System.Windows.Forms;
using Minesweeper.Models;
using Minesweeper.Views;

public enum Item { Mine, Flag };

namespace Minesweeper {
    
    public class Tile {

        public Coordinates Position { get; set; }
        public List<Item> Items { get; set; }
        public List<Tile> Neighbours { get; set; }
        public bool IsRevealed { get; set; }

        public TileView View { get; set; }

        public Tile(Coordinates position) {
            Position = position;
            Items = new List<Item>();
            Neighbours = new List<Tile>();
            IsRevealed = false;

            View = new TileView(Position);
            View.MouseDown += OnTileClick;
        }

        private void OnTileClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ToggleReveal();
        }

        private void ToggleReveal()
        {
            IsRevealed = !IsRevealed;
            View.RevealState(IsRevealed);
        }
    }
}
