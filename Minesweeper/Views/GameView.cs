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
            _clock.Text = _watch.Elapsed.Seconds.ToString();
        }

        public void UpdateBombCount(int value) {
            int bombs = Int32.Parse(_remainingBombs.Text);
            if (bombs > 0)
                _remainingBombs.Text = (bombs + value).ToString();
        }

        public void ShowBoard(Board board, int bombCount) {
            SetWindowSize(board.Dimension);
            _clock = new Label();
            _clock.Parent = Window;
            _clock.Location = new Point(10, Window.ClientSize.Height - 20);

            _watch.Start();

            Timer timer = new Timer();
            timer.Start();
            timer.Tick += UpdateClock;

            _remainingBombs = new Label();
            _remainingBombs.Parent = Window;
            _remainingBombs.Location = new Point(Window.ClientSize.Width - 40, Window.ClientSize.Height - 20);
            _remainingBombs.Text = bombCount.ToString();

            Window.Show();
        }

        public void EndScreen() {
            Form form = new Form();
            Label label = new Label();
            label.Parent = form;
            label.Text = "Game Over";
            label.AutoSize = true;
            label.Font = new Font("Arial", 36, FontStyle.Bold);
            Window.Close();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }
    }
}