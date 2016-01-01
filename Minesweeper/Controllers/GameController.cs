using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper {
    class GameController {

        private Board _board;
        private GameView _gameView;
        private Dictionary<Field, FieldView> _fieldMap;
        private Dictionary<FieldView, Field> _fieldViewMap;
        private int _bombCount;

        public GameController(GameDifficulty difficulty) {
            _gameView = new GameView();
            if (difficulty == GameDifficulty.Easy) {
                _bombCount = 10;
                _board = new Board(new Coordinates(10, 10));
            } else if (difficulty == GameDifficulty.Standart) {
                _bombCount = 30;
                _board = new Board(new Coordinates(15, 15));
            } else{
                _bombCount = 50;
                _board = new Board(new Coordinates(25, 25));
            }
        }

        void GameOver() {
            _gameView.EndScreen();
        }

        void AssignViewToFields() {
            _fieldMap = new Dictionary<Field, FieldView>();
            _fieldViewMap = new Dictionary<FieldView, Field>();
            for (int i = 0; i < _board.Dimension.X; i++) {
                for (int j = 0; j < _board.Dimension.Y; j++) {
                    Field field = _board.Fields[i, j];
                    FieldView fieldView = new FieldView(field, _gameView.Window);
                    fieldView.MouseDown += OnFieldClick;
                    _fieldMap.Add(field, fieldView);
                    _fieldViewMap.Add(fieldView, field);
                }
            }
        }

        void TestWin() {
            bool allFlagged = true;
            for (int i = 0; i < _board.Dimension.X; i++) {
                for (int j = 0; j < _board.Dimension.Y; j++) {
                    if (!(_board.Fields[i, j].Items.Contains(FieldItem.Mine) && _board.Fields[i, j].Items.Contains(FieldItem.Flag)))
                        allFlagged = false;
                }
            }
            if (allFlagged)
                GameOver();
        }

        void RevealField(FieldView fieldView) {
            Field field = _fieldViewMap[fieldView];
            if (field.Items.Contains(FieldItem.Flag))
                return;
            if (field.Items.Contains(FieldItem.Mine))
                GameOver();
            fieldView.Reveal(field);
            field.IsRevealed = true;
            _fieldViewMap[fieldView] = field;
            if (field.NeighbourMineCount == 0 && !field.Items.Contains(FieldItem.Mine)) {
                foreach (Field neighbour in field.Neighbours) {
                        FieldView neighbourView = _fieldMap[neighbour];
                        if (!neighbour.IsRevealed)
                            RevealField(neighbourView);
                }
            }
        }

        void FlagHandler(FieldView fieldView) {
            Field field = _fieldViewMap[fieldView];
            if (field.IsRevealed)
                return;
            if (!field.Items.Contains(FieldItem.Flag)) {
                fieldView.SetFlag(true);
                field.Items.Add(FieldItem.Flag);
                Console.WriteLine("Flagged field[" + field.Position.GetCoordinates() + "]");
            } else {
                fieldView.SetFlag(false);
                field.Items.Remove(FieldItem.Flag);
                Console.WriteLine("Unflagged field[" + field.Position.GetCoordinates() + "]");
            }
            _fieldViewMap[fieldView] = field;
        }

        void OnFieldClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            FieldView fieldView = (FieldView)sender;
            if (e.Button == MouseButtons.Left)
                RevealField(fieldView);
            else if (e.Button == MouseButtons.Right)
                FlagHandler(fieldView);
        }

        public void InitializeGame() {
            _board.InitializeFields();
            _board.AssignNeighbourFields();
            _board.PlantMines(_bombCount);
            AssignViewToFields();
        }

        public void Update() {
            _gameView.ShowBoard(_board);
        }

    }
}
