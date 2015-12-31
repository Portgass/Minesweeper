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

        public void InitializeFields() {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    _fields[i, j] = new Field(new Coordinates(i, j));
                }
            }
        }

        public void SetNeighbourMineCount() {
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    Field field = _fields[i, j];
                    if (i != 0) {
                        if (j != 0) {
                            if (_fields[i - 1, j - 1].Items.Contains(FieldItem.Mine))
                                field.NeighbourMineCount += 1;
                        }
                        if (_fields[i - 1, j].Items.Contains(FieldItem.Mine))
                            field.NeighbourMineCount += 1;
                        if (j != _dimension.Y - 1) {
                            if (_fields[i - 1, j + 1].Items.Contains(FieldItem.Mine))
                                field.NeighbourMineCount += 1;
                        }
                    }
                    if (j != 0)
                        if (_fields[i, j - 1].Items.Contains(FieldItem.Mine))
                        field.NeighbourMineCount += 1;
                    if (j != _dimension.Y - 1)
                        if (_fields[i, j + 1].Items.Contains(FieldItem.Mine))
                        field.NeighbourMineCount += 1;
                    if (i != _dimension.X - 1) {
                        if (j != 0) {
                            if (_fields[i + 1, j - 1].Items.Contains(FieldItem.Mine))
                                field.NeighbourMineCount += 1;
                        }
                        if (_fields[i + 1, j].Items.Contains(FieldItem.Mine))
                            field.NeighbourMineCount += 1;
                        if (j != _dimension.Y - 1) {
                            if (_fields[i + 1, j + 1].Items.Contains(FieldItem.Mine))
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

            int boardPosition = 0;
            for (int i = 0; i < _dimension.X; i++) {
                for (int j = 0; j < _dimension.Y; j++) {
                    if (mineCoords.Contains(boardPosition)) {
                        _fields[i, j].Items.Add(FieldItem.Mine);
                        Console.WriteLine("Field[" + _fields[i, j].Position.GetCoordinates() + "] new Mine");
                    }
                    boardPosition += 1;
                }
            }
            SetNeighbourMineCount();
        }
    }
}
