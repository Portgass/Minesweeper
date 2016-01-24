using System.Collections.Generic;
using Minesweeper.Views;

namespace Minesweeper.Models
{
    public class Board
    {

        public Coordinates Dimension { get; set; }
        public List<Tile> Tiles { get; set; }

        public BoardView View { get; set; }

        public Board(Coordinates dimension)
        {
            Dimension = dimension;
            Tiles = new List<Tile>();
            View = new BoardView();

            InitializeTiles();
            View.Window.Show();
        }

        private void InitializeTiles()
        {
            for (var i = 0; i < Dimension.X; i++)
            {
                for (var j = 0; j < Dimension.Y; j++)
                {
                    var tile = new Tile(new Coordinates(i, j)) {View = {Parent = View.Window}};
                    Tiles.Add(tile);
                }
            }
        }

        private void PlantMines()
        {
            
        }

        
    }
}
