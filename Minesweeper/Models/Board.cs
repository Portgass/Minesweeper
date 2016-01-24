using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper.Views;

namespace Minesweeper.Models
{
    public class Board
    {

        public Coordinates Dimension { get; set; }
        public List<Tile> Tiles { get; set; }
        private int MineCount { get; set; }
        private List<int> MineAtIDs { get; set; } 

        public BoardView View { get; set; }

        public Board(Coordinates dimension)
        {
            Dimension = dimension;
            Tiles = new List<Tile>();
            View = new BoardView(Dimension);

            MineCount = 40;

            InitializeTiles();
            AssignNeighbours();
            PlantMines();
            View.Window.Show();
        }

        private void InitializeTiles()
        {
            var id = 0;
            for (var i = 0; i < Dimension.X; i++)
            {
                for (var j = 0; j < Dimension.Y; j++)
                {
                    var tile = new Tile(id, new Coordinates(i, j)) {View = {Parent = View.Window}};
                    Tiles.Add(tile);
                    id += 1;
                }
            }
        }

        private void AssignNeighbours()
        {
            foreach (var tile in Tiles)
            {
                for (var i = -1; i <= 1; i++)
                {
                    for (var j = -1; j <= 1; j++)
                    {
                        if ((i == 0) && (j == 0))
                            continue;
                        
                        var position = new Coordinates(tile.Position.X + i, tile.Position.Y + j);

                        if ((position.X < 0) || (position.Y < 0) || (position.X >= Dimension.X) || (position.Y >= Dimension.Y))
                            continue;

                        tile.Neighbours.Add(Tiles.First(t => (t.Position.X == position.X) && (t.Position.Y == position.Y)));
                    }
                }
            }
        }

        private void GenerateMineLocations()
        {
            MineAtIDs = new List<int>();
            var maxRandomValue = (Dimension.X * Dimension.Y) - 1;
            var random = new Random();

            for (var i = 0; i < MineCount; i++)
            {
                int rndNum;
                do
                {
                    rndNum = random.Next(maxRandomValue);
                } while (MineAtIDs.Contains(rndNum));
                MineAtIDs.Add(rndNum);
            }
        }

        private void PlantMines()
        {
            GenerateMineLocations();

            foreach (var id in MineAtIDs)
            {
                Tiles.First(tile => tile.ID == id).Items.Add(Item.Mine);
            }
        }
    }
    
}
