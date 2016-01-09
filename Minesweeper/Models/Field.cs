using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum FieldItem { Mine, Flag };

namespace Minesweeper {

    /// <summary>
    /// Base unit on board.
    /// </summary>
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

        private List<Field> _neighbours;

        public List<Field> Neighbours {
            get { return _neighbours; }
            set { _neighbours = value; }
        }

        private int _neighbourMineCount;

        public int NeighbourMineCount {
            get { return _neighbourMineCount; }
            set { _neighbourMineCount = value; }
        }

        private bool _isRevealed;

        public bool IsRevealed {
            get { return _isRevealed; }
            set { _isRevealed = value; }
        }

        /// <summary>
        /// Initializes field with position. 
        /// Field isn't revealed and has set 0 neighbouring mines.
        /// </summary>
        /// <param name="position"></param>
        public Field(Coordinates position) {
            _position = position;
            _items = new List<FieldItem>();
            _neighbours = new List<Field>();
            _neighbourMineCount = 0;
            _isRevealed = false;
            // Console.WriteLine("Created field with position: " + position.GetCoordinates());
        }
    }
}
