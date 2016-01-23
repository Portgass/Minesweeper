using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Contains all game difficulties.
/// </summary>
enum GameDifficulty { Easy, Standard, Hard };
/// <summary>
/// Contains all game modes.
/// </summary>
enum GameMode { Normal, Extreme }

namespace Minesweeper {
    class BoardController {

        private Board _board;
        private GameView _gameView;
        private Dictionary<Field, FieldView> _fieldMap;
        private Dictionary<FieldView, Field> _fieldViewMap;
        private int _mineCount;
        private GameMode _gamemode;

        /// <summary>
        /// Initializes game controller, assignes view to it and creates board with set difficulty.
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="gamemode"></param>
        public BoardController(GameDifficulty difficulty, GameMode gamemode) {
            _gameView = new GameView();
            _gamemode = gamemode;
            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    _mineCount = 10;
                    _board = new Board(new Coordinates(8, 8));
                    break;
                case GameDifficulty.Standard:
                    _mineCount = 40;
                    _board = new Board(new Coordinates(16, 16));
                    break;
                case GameDifficulty.Hard:
                    _mineCount = 99;
                    _board = new Board(new Coordinates(30, 16));
                    break;
                default:
                    _mineCount = 10;
                    _board = new Board(new Coordinates(8, 8));
                    break;
            }
        }

        /// <summary>
        /// Assigns view to each field on board and adds callback(on click) for views.
        /// Uses two dictionaries for two way finding. Classes may be better.
        /// </summary>
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

        /// <summary>
        /// Checks field's contents and reveals it's corresponding view.
        /// Ends game if field contains mine.
        /// Also reveals neighbouring fields if field has no neighbouring mines.
        /// </summary>
        /// <param name="fieldView"></param>
        void RevealField(FieldView fieldView) {
            Field field = _fieldViewMap[fieldView];
            if (field.Items.Contains(FieldItem.Flag))
                return;
            if (field.Items.Contains(FieldItem.Mine))
                // Player revealed mine and loses game.
                _gameView.EndScreen(false);
            fieldView.Reveal(field);
            field.IsRevealed = true;
            _fieldViewMap[fieldView] = field;
            if (field.NeighbourMineCount == 0 && !field.Items.Contains(FieldItem.Mine)) {
                // Reveal all neighbours if they aren't already.
                foreach (Field neighbour in field.Neighbours) {
                        FieldView neighbourView = _fieldMap[neighbour];
                        if (!neighbour.IsRevealed)
                            RevealField(neighbourView);
                }
            }
        }

        /// <summary>
        /// Checks if field is not revealed and places(removes) flags from it.
        /// Records correctly placed flags.
        /// </summary>
        /// <param name="fieldView"></param>
        void FlagHandler(FieldView fieldView) {
            Field field = _fieldViewMap[fieldView];
            if (field.IsRevealed)
                return;
            if (!field.Items.Contains(FieldItem.Flag)) {
                fieldView.SetFlag(true);
                field.Items.Add(FieldItem.Flag);
                // Console.WriteLine("Flagged field[" + field.Position.GetCoordinates() + "]");
                _gameView.UpdateBombCount(-1);
                if (field.Items.Contains(FieldItem.Mine))
                    // Player flagged the right field.
                    _mineCount -= 1;
            } else {
                fieldView.SetFlag(false);
                field.Items.Remove(FieldItem.Flag);
                // Console.WriteLine("Unflagged field[" + field.Position.GetCoordinates() + "]");
                _gameView.UpdateBombCount(1);
                if (field.Items.Contains(FieldItem.Mine))
                    // Player unfortunately unflaged the field that contains bomb.
                    _mineCount += 1;
            }
            _fieldViewMap[fieldView] = field;
        }

        /// <summary>
        /// Runs functions based on user input.
        /// Checks if winning condition is true.
        /// Sender is FieldView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnFieldClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            FieldView fieldView = (FieldView)sender;
            if (e.Button == MouseButtons.Left)
                RevealField(fieldView);
            else if (e.Button == MouseButtons.Right)
                FlagHandler(fieldView);
            // Checking if all mines are flaged.
            if (_mineCount == 0)
                _gameView.EndScreen(true);
        }

        /// <summary>
        /// Prepares board for new game and assigns view to its elements.
        /// </summary>
        public void InitializeGame() {
            _board.InitializeFields();
            _board.AssignNeighbourFields(_gamemode);
            _board.PlantMines(_mineCount);
            AssignViewToFields();
        }

        /// <summary>
        /// Opens game view.
        /// </summary>
        public void Start() {
            _gameView.ShowBoard(_board, _mineCount);
        }

    }
}
