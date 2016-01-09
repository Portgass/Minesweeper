using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {

    /// <summary>
    /// Game platform, most of the game mechanics are operated from here.
    /// </summary>
    class Board {

        private Coordinates _dimension;

        public Coordinates Dimension {
            get { return _dimension; }
            set { _dimension = value; }
        }
        
        private Field[,] _fields;

        public Field[,] Fields {
            get { return _fields; }
            set { _fields = value; }
        }

        /// <summary>
        /// Initializes board with dimensions and creates all fields in it.
        /// </summary>
        /// <param name="dimension"></param>
        public Board(Coordinates dimension) {
            _dimension = dimension;
            _fields = new Field[dimension.X, dimension.Y];
            // Console.WriteLine("Created board with dimensions: " + dimension.GetCoordinates());
        }

        /// <summary>
        /// Assigns neighbouring fields, that are touching the field on the sides or corners.
        /// Tile ... T
        /// Neighbours ... N
        /// Other Fields ... o
        /// o o o o o
        /// o N N N o
        /// o N T N o
        /// o N N N o
        /// o o o o o
        /// Two modes: 
        /// 1) Normal - Fields on the border of board have less neighbours, because nothing lies beyond the border.
        /// T N o o o
        /// N N o o o
        /// o o o o o
        /// o o o o o
        /// o o o o o
        /// 2) Extreme - Fields on the border have assigned fields on the other side of board instead of nothing.
        /// T N o o N
        /// N N o o N
        /// o o o o o
        /// o o o o o
        /// N N o o N
        /// </summary>
        /// <param name="gamemode"></param>
        public void AssignNeighbourFields(GameMode gamemode) {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    Field field = _fields[i, j];

                    // Iterates over all neighbouring positions.
                    for (int x = i - 1; x <= i + 1; x++) {
                        for (int y = j - 1; y <=  j + 1; y++) {
                            if (gamemode == GameMode.Normal) {
                                // We don't care what's outside the board.
                                if ((x < 0) || (y < 0) || (x >= _dimension.X) || (y >= _dimension.Y))
                                    continue;
                                field.Neighbours.Add(_fields[x, y]);
                            } else {
                                // Checks if field is outside the board and if it is, assigns the field on the other side of board instead.
                                int tempX = x;
                                int tempY = y;
                                if (x < 0)
                                    tempX = _dimension.X - 1;
                                if (y < 0)
                                    tempY = _dimension.Y - 1;
                                if (x >= _dimension.X)
                                    tempX = 0;
                                if (y >= _dimension.Y)
                                    tempY = 0;
                                field.Neighbours.Add(_fields[tempX, tempY]);
                            }
                        }
                    }

                    _fields[i, j] = field;
                }
            }
        }

        /// <summary>
        /// Fills array of fields with new fields with correct position.
        /// </summary>
        public void InitializeFields() {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    Field field = new Field(new Coordinates(i, j));
                    _fields[i, j] = field;
                }
            }
        }

        /// <summary>
        /// Iterates over all fields and discover all mines that are neighbouring them. And sets the value as NeighbourMineCount
        /// </summary>
        public void SetNeighbourMineCount() {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    Field field = _fields[i, j];
                    foreach (Field neighbour in field.Neighbours) {
                        if (neighbour.Items.Contains(FieldItem.Mine)) {
                            field.NeighbourMineCount += 1;
                        }
                    }
                    _fields[i, j] = field;
                }
            }
        }

        /// <summary>
        /// Generates mineCount of unique numbers between 0 and sum of all fields and plants mines to corresponding fields.
        /// Also makes fields aware how many mines are in their neighbours.
        /// </summary>
        /// <param name="mineCount"></param>
        public void PlantMines(int mineCount) {
            int maxRnd = (_dimension.X * _dimension.Y) - 1;
            List<int> mineCoords = new List<int>();
            Random rnd = new Random();

            // Console.WriteLine("Generating " + mineCount + " random numbers between 0 and " + maxRnd);

            for (int i = 0; i < mineCount; i++) {
                int rndNum;
                do {
                    // We don't want same number twice.
                    rndNum = rnd.Next(maxRnd);
                } while (mineCoords.Contains(rndNum));
                mineCoords.Add(rndNum);
                // Console.WriteLine("Random number " + (i + 1) + ": " + rndNum);
            }

            // Console.WriteLine("Planting " + mineCount + " mines");

            // Iterates over all fields and if current field sum is equals one of the random numbers, plants mine to field.
            int boardPosition = 0;
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    if (mineCoords.Contains(boardPosition)) {
                        _fields[i, j].Items.Add(FieldItem.Mine);
                        // Console.WriteLine("Set mine on field[" + _fields[i, j].Position.GetCoordinates() + "]");
                    }
                    boardPosition += 1;
                }
            }
            SetNeighbourMineCount();
        }
    }
}
