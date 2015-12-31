using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class GameController {

        private Board _board;
        private WinFormsView _gameView;
        private Dictionary<Field, FieldView> _fieldMap;
        private Dictionary<FieldView, Field> _fieldViewMap;

        public GameController() {
            _gameView = new WinFormsView();
        }

        void AssignViewToFields() {
            _fieldMap = new Dictionary<Field, FieldView>();
            _fieldViewMap = new Dictionary<FieldView, Field>();
            for (int i = 0; i < _board.Dimension.X; i++) {
                for (int j = 0; j < _board.Dimension.Y; j++) {
                    Field field = _board.Fields[i, j];
                    FieldView fieldView = new FieldView(field, _gameView.GameWindow);
                    fieldView.Click += OnFieldClick;
                    _fieldMap.Add(field, fieldView);
                    _fieldViewMap.Add(fieldView, field);
                }
            }
        }

        void RevealField(FieldView fieldView) {
            Field field = _fieldViewMap[fieldView];
            fieldView.Reveal(field);
            field.IsRevealed = true;
            _fieldViewMap[fieldView] = field;
            if (field.NeighbourMineCount == 0) {
                foreach (Field neighbour in field.Neighbours) {
                    if (neighbour.NeighbourMineCount == 0) {
                        FieldView neighbourView = _fieldMap[neighbour];
                        if (!neighbour.IsRevealed)
                            RevealField(neighbourView);
                    }
                }
            }
        }

        void OnFieldClick(object sender, EventArgs e) {
            FieldView fieldView = (FieldView)sender;
            RevealField(fieldView);
        }

        public void InitializeGame() {
            _board = new Board(new Coordinates(15, 15));
            _board.InitializeFields();
            _board.AssignNeighbourFields();
            _board.PlantMines(30);
            AssignViewToFields();
        }

        public void Update() {
            _gameView.ShowBoard(_board);
        }

    }
}
