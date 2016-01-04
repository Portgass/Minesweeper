using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {
    class GameView : View {

        private Label _clock;

        public Label Clock {
            get { return _clock; }
            set { _clock = value; }
        }

        private Label _remainingBombs;

        private System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();

        void SetWindowSize(Coordinates size) {
            Window.ClientSize = new Size(size.X * 32, size.Y * 32 + 32);
        }

        void UpdateClock(object sender, EventArgs e) {
            _clock.Text = "Time elapsed: " + Math.Floor(_watch.Elapsed.TotalSeconds).ToString();
        }

        public void UpdateBombCount(int value) {
            int bombs = Int32.Parse(_remainingBombs.Text.Remove(0, 15));
            if (bombs > 0)
                _remainingBombs.Text = "Avaiable flags: " + (bombs + value).ToString();
        }

        public void ShowBoard(Board board, int bombCount) {
            SetWindowSize(board.Dimension);
            Window.BackgroundImage = Properties.Resources.panel;

            _clock = new Label();
            _clock.Parent = Window;
            _clock.BackColor = Color.Transparent;
            _clock.AutoSize = true;
            _clock.Font = new Font("Arial", 10, FontStyle.Bold);
            _clock.Location = new Point(6, Window.ClientSize.Height - 24);

            _watch.Start();

            Timer timer = new Timer();
            timer.Start();
            timer.Tick += UpdateClock;

            _remainingBombs = new Label();
            _remainingBombs.Parent = Window;
            _remainingBombs.BackColor = Color.Transparent;
            _remainingBombs.AutoSize = true;
            _remainingBombs.Font = new Font("Arial", 10, FontStyle.Bold);
            _remainingBombs.Location = new Point(Window.ClientSize.Width - 120, Window.ClientSize.Height - 24);
            _remainingBombs.Text = "Avaiable flags: " + bombCount.ToString();

            Window.Show();
        }

        public void EndScreen(bool winner) {
            Form form = new Form();
            form.ClientSize = new Size(400, 200);
            if (winner) {
                form.BackgroundImage = Properties.Resources.winner;
                Label time = new Label();
                time.Parent = form;
                time.BackColor = Color.Transparent;
                time.Size = new Size(200, 60);
                time.TextAlign = ContentAlignment.BottomRight;
                time.Font = new Font("Arial", 40, FontStyle.Bold);
                time.ForeColor = Color.FromArgb(255, 216, 0);
                time.Location = new Point(154, 106);
                time.Text = _clock.Text.Remove(0, 13);
                if (Int32.Parse(time.Text) >= 1000) {
                    time.Text = ">999";
                }
            } else {
                form.BackgroundImage = Properties.Resources.game_over;
            }
            Window.Close();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }
    }
}