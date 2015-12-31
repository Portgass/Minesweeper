using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum FieldItem { Mine };

namespace Minesweeper {
    class Field {

        private Coordinates _position;

        public Coordinates Position {
            get { return _position; }
            set { _position = value; }
        }

        private List<FieldItem> _items;

        public List<FieldItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        private int _neighbourMineCount;

        public int NeighbourMineCount {
            get { return _neighbourMineCount; }
            set { _neighbourMineCount = value; }
        }

        public Field(Coordinates position) {
            _position = position;
            _items = new List<FieldItem>();
            Console.WriteLine("Created field with position: " + position.GetCoordinates());
        }
    }
}
