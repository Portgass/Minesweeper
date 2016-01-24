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
        public bool IsRevealed { get; set; }

        public TileView View { get; set; }

        public Tile(int id, Coordinates position)
        {
            ID = id;
            Position = position;
            Items = new ObservableCollection<Item>();
            Neighbours = new List<Tile>();
            IsRevealed = false;

            View = new TileView(Position);
            View.MouseDown += OnTileClick;
            Items.CollectionChanged += CheckContent;
        }

        private void OnTileClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ToggleReveal();
            if (e.Button == MouseButtons.Right)
                ToggleFlag();
        }

        private void ToggleReveal()
        {
            if (Items.Contains(Item.Flag))
                return;

            if (IsRevealed)
                return;

            IsRevealed = !IsRevealed;
            View.RevealState(IsRevealed);
            CheckNeighbours();
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

        public void CheckNeighbours()
        {
            if (IsRevealed)
            {
                var neighbouringMines = Neighbours.Count(neighbour => neighbour.Items.Contains(Item.Mine));
                View.DisplayNeighbourContent(neighbouringMines);

                if (neighbouringMines == 0)
                {
                    Neighbours.FindAll(neighbour => neighbour.IsRevealed == false).ForEach(neighbour => neighbour.ToggleReveal());
                }
            }
            else
            {
                View.DisplayNeighbourContent(0);
            }
        }
    }
}
