using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
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

        public Board(Coordinates dimension) {
            _dimension = dimension;
            _fields = new Field[dimension.X, dimension.Y];
            Console.WriteLine("Created board with dimensions: " + dimension.GetCoordinates());
        }

        public void AssignNeighbourFields(GameMode gamemode) {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    Field field = _fields[i, j];

                    for (int x = i - 1; x <= i + 1; x++) {
                        for (int y = j - 1; y <=  j + 1; y++) {
                            if ((x < 0) || (y < 0) || (x >= _dimension.X) || (y >= _dimension.Y)) {
                                Console.WriteLine(x + ", " + y);
                                continue;
                            }
                            else {
                                Console.WriteLine(x + ", " + y);
                                field.Neighbours.Add(_fields[x, y]);
                            }
                        }
                    }

                    _fields[i, j] = field;
                }
            }
        }

        public void InitializeFields() {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    Field field = new Field(new Coordinates(i, j));
                    _fields[i, j] = field;
                }
            }
        }

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

        public void PlantMines(int mineCount) {
            int maxRnd = (_dimension.X * _dimension.Y) - 1;
            List<int> mineCoords = new List<int>();
            Random rnd = new Random();

            Console.WriteLine("Generating " + mineCount + " random numbers between 0 and " + maxRnd);

            for (int i = 0; i < mineCount; i++) {
                int rndNum;
                do {
                    rndNum = rnd.Next(maxRnd);
                } while (mineCoords.Contains(rndNum));
                mineCoords.Add(rndNum);
                Console.WriteLine("Random number " + (i + 1) + ": " + rndNum);
            }

            Console.WriteLine("Planting " + mineCount + " mines");
            int boardPosition = 0;
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    if (mineCoords.Contains(boardPosition)) {
                        _fields[i, j].Items.Add(FieldItem.Mine);
                        Console.WriteLine("Set mine on field[" + _fields[i, j].Position.GetCoordinates() + "]");
                    }
                    boardPosition += 1;
                }
            }
            SetNeighbourMineCount();
        }
    }
}
