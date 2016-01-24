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
            View.MouseEnter += OnTileHover;
            View.MouseLeave += OnTileHover;
            Items.CollectionChanged += CheckContent;
        }

        private void OnTileClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Reveal();
            if (e.Button == MouseButtons.Right)
                ToggleFlag();
        }

        private void OnTileHover(object sender, EventArgs e)
        {
            View.HighlightTile();
            NeighbourHighlight();
        }

        public void NeighbourHighlight()
        {
            IsHighlighted = !IsHighlighted;

            var lineNeighbours = Neighbours.FindAll(neighbour => (neighbour.Position.X == Position.X) || (neighbour.Position.Y == Position.Y));
            foreach (var neighbour in lineNeighbours)
            {
                neighbour.View.HighlightNeighbour();
                neighbour.NeighbourHighlight();
            }
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
