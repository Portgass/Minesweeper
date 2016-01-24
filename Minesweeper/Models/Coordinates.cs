namespace Minesweeper.Models {

    /// <summary>
    /// Defines the units in which are all game objects represented.
    /// </summary>
    public class Coordinates {
        public int X { get; set; }

        public int Y { get; set; }

        public Coordinates(int x, int y) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Helps with printing out the coordinates.
        /// </summary>
        public string GetCoordinates() {
            return X + ", " + Y;
        }
    }
}