using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        void FlagHandler(FieldView fieldView) {
            Field field = _fieldViewMap[fieldView];
            if (field.IsRevealed)
                return;
            if (!field.Items.Contains(FieldItem.Flag)) {
                fieldView.SetFlag(true);
                field.Items.Add(FieldItem.Flag);
            } else {
                fieldView.SetFlag(false);
                field.Items.Remove(FieldItem.Flag);
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
            _board = new Board(new Coordinates(15, 15));
            _board.InitializeFields();
            _board.AssignNeighbourFields();
            _board.PlantMines(30);
            AssignViewToFields();
        }

        public void Update() {
            _gameView.ShowBoard(_board);
        }

        public void StartMenu() {
            WinFormsView menu = new WinFormsView();
            System.Windows.Forms.Form window = menu.GameWindow;
            window.Size = new System.Drawing.Size(400, 400);

            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Parent = window;
            label.Text = "Minesweeper";
            label.Font = new System.Drawing.Font("Arial", 36, System.Drawing.FontStyle.Bold);
            label.AutoSize = true;
            label.Left = (window.ClientSize.Width - label.Width) / 2;
            label.Top = 50;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.Run(window);
        }

    }
}
