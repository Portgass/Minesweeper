using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Minesweeper.Models;
using Minesweeper.Views;

public enum Item { Mine, Flag };

namespace Minesweeper {
    public class Tile {

        public int ID { get; set; }
        public Coordinates Position { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public List<Tile> Neighbours { get; set; }
        public int NeighbouringMines { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsHighlighted { get; set; }

        public TileView View { get; set; }

        public Tile(int id, Coordinates position)
        {
            ID = id;
            Position = position;
            Items = new ObservableCollection<Item>();
            Neighbours = new List<Tile>();
            NeighbouringMines = 0;
            IsRevealed = false;
            IsHighlighted = false;

            View = new TileView(Position);
            View.MouseDown += OnTileClick;
            View.MouseEnter += OnTileMouseEnter;
            View.MouseLeave += OnTileMouseLeave;
            Items.CollectionChanged += CheckContent;
        }

        private void OnTileClick(object sender, MouseEventArgs e)
        {
            ToggleHighlight();

            if (e.Button == MouseButtons.Left)
                Reveal();
            if (e.Button == MouseButtons.Right)
                ToggleFlag();

            ToggleHighlight();
        }

        private void OnTileMouseEnter(object sender, EventArgs e)
        {
            ToggleHighlight();
        }

        private void OnTileMouseLeave(object sender, EventArgs e)
        {
            ToggleHighlight();
        }

        private void ToggleHighlight()
        {
            IsHighlighted = !IsHighlighted;
            View.HighlightTile();

            NeighbourHighlight(new Coordinates(0, -1), IsHighlighted);
            NeighbourHighlight(new Coordinates(0, 1), IsHighlighted);
            NeighbourHighlight(new Coordinates(-1, 0), IsHighlighted);
            NeighbourHighlight(new Coordinates(1, 0), IsHighlighted);
        }

        public void NeighbourHighlight(Coordinates coords, bool mouseEnter)
        {
            var neighbour = Neighbours.Find(n => (n.Position.X == (Position.X + coords.X)) && n.Position.Y == (Position.Y + coords.Y));

            if (neighbour == null)
                return;

            neighbour.IsHighlighted = !neighbour.IsHighlighted;
            neighbour.View.HighlightTile();

            neighbour.NeighbourHighlight(coords, IsHighlighted);
        }

        private void Reveal()
        {
            if (Items.Contains(Item.Flag) || IsRevealed)
                return;

            IsRevealed = true;

            NeighbouringMines = Neighbours.Count(neighbour => neighbour.Items.Contains(Item.Mine));
            View.RevealTileContent(NeighbouringMines);

            if (NeighbouringMines == 0)
                Neighbours.FindAll(neighbour => neighbour.IsRevealed == false).ForEach(neighbour => neighbour.Reveal());
        }

        private void ToggleFlag()
        {
            if (IsRevealed)
                return;

            if (Items.Contains(Item.Flag))
            {
                Items.Remove(Item.Flag);
                View.DisplayFlag(false);
            }
            else
            {
                Items.Add(Item.Flag);
                View.DisplayFlag(true);
            }
        }

        private void CheckContent(object sender, EventArgs e)
        {
            if (Items.Contains(Item.Mine))
                View.DisplayMine();
        }
    }
}
