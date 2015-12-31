using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class GameController {

        private Board _board;
        private WinFormsView _gameView;
        private Dictionary<FieldView, Field> _fieldMap;

        public GameController() {
            _gameView = new WinFormsView();
        }

        public void AssignViewToFields() {
            _fieldMap = new Dictionary<FieldView, Field>();
            for (int i = 0; i < _board.Dimension.X; i++) {
                for (int j = 0; j < _board.Dimension.Y; j++) {
                    Field field = _board.Fields[i, j];
                    FieldView fieldView = new FieldView(field, _gameView.GameWindow);
                    fieldView.Click += ChangeText;
                    _fieldMap.Add(fieldView, field);
                }
            }
        }

        public void ChangeText(object sender, EventArgs e) {
            FieldView fieldView = (FieldView)sender;
            Field field = _fieldMap[fieldView];
            if(field.Items.Contains(FieldItem.Mine))
                fieldView.Text = "*";
            else
                fieldView.Text = field.NeighbourMineCount.ToString();
        }

        public void InitializeGame() {
            _board = new Board(new Coordinates(15, 15));
            _board.InitializeFields();
            _board.PlantMines(30);
            AssignViewToFields();
            _fieldMap.ToList().ForEach(x => Console.WriteLine(x.Key));
        }

        public void Update() {
            _gameView.ShowBoard(_board);
        }

    }
}
