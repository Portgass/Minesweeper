using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

enum GameDifficulty { Easy, Standard, Hard };
enum GameMode { Normal, Extreme }

namespace Minesweeper {
    class GameController {

        private Board _board;
        private GameView _gameView;
        private Dictionary<Field, FieldView> _fieldMap;
        private Dictionary<FieldView, Field> _fieldViewMap;
        private int _bombCount;
        private GameMode _gamemode;

        public GameController(GameDifficulty difficulty, GameMode gamemode) {
            _gameView = new GameView();
            _gamemode = gamemode;
            if (difficulty == GameDifficulty.Easy) {
                _bombCount = 10;
                _board = new Board(new Coordinates(8, 8));
            } else if (difficulty == GameDifficulty.Standard) {
                _bombCount = 40;
                _board = new Board(new Coordinates(16, 16));
            } else{
                _bombCount = 99;
                _board = new Board(new Coordinates(30, 16));
            }
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

        void RevealField(FieldView fieldView) {
            Field field = _fieldViewMap[fieldView];
            if (field.Items.Contains(FieldItem.Flag))
                return;
            if (field.Items.Contains(FieldItem.Mine))
                _gameView.EndScreen(false);
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
                _gameView.UpdateBombCount(-1);
                if (field.Items.Contains(FieldItem.Mine))
                    _bombCount -= 1;
            } else {
                fieldView.SetFlag(false);
                field.Items.Remove(FieldItem.Flag);
                Console.WriteLine("Unflagged field[" + field.Position.GetCoordinates() + "]");
                _gameView.UpdateBombCount(1);
                if (field.Items.Contains(FieldItem.Mine))
                    _bombCount += 1;
            }
            _fieldViewMap[fieldView] = field;
        }

        void OnFieldClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            FieldView fieldView = (FieldView)sender;
            if (e.Button == MouseButtons.Left)
                RevealField(fieldView);
            else if (e.Button == MouseButtons.Right)
                FlagHandler(fieldView);
            if (_bombCount == 0)
                _gameView.EndScreen(true);
        }

        public void InitializeGame() {
            _board.InitializeFields();
            _board.AssignNeighbourFields(_gamemode);
            _board.PlantMines(_bombCount);
            AssignViewToFields();
        }

        public void Update() {
            _gameView.ShowBoard(_board, _bombCount);
        }

    }
}
