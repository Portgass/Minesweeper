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

        /// <summary>
        /// Displaying time in game window.
        /// </summary>
        public Label Clock {
            get { return _clock; }
            set { _clock = value; }
        }
        
        private Label _remainingBombs;

        /// <summary>
        /// Counts game time.
        /// </summary>
        private System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();

        /// <summary>
        /// Sets windows size, 1 unit is 32 pixels.
        /// </summary>
        /// <param name="size"></param>
        void SetWindowSize(Coordinates size) {
            Window.ClientSize = new Size(size.X * 24, size.Y * 24 + 24);
        }

        /// <summary>
        /// Changes displayed game time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpdateClock(object sender, EventArgs e) {
            _clock.Text = "Time elapsed: " + Math.Floor(_watch.Elapsed.TotalSeconds).ToString();
        }

        /// <summary>
        /// Changes displayed number of flags avaiable.
        /// It could use rework, at least use more variables.
        /// </summary>
        /// <param name="value"></param>
        public void UpdateBombCount(int value) {
            // Remove the text and convert to int.
            int bombs = Int32.Parse(_remainingBombs.Text.Remove(0, 15));
            if (bombs > 0)
                _remainingBombs.Text = "Avaiable flags: " + (bombs + value).ToString();
        }

        /// <summary>
        /// Sets up the game view.
        /// Displays game time, avaiable mines count.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="bombCount"></param>
        public void ShowBoard(Board board, int bombCount) {
            SetWindowSize(board.Dimension);
            Window.BackgroundImage = Properties.Resources.panel;
            Window.BackColor = Color.FromArgb(66, 66, 66);

            // Setting clock visuals.
            _clock = new Label();
            _clock.Parent = Window;
            _clock.BackColor = Color.Transparent;
            _clock.AutoSize = true;
            _clock.Font = new Font("Arial", 10, FontStyle.Bold);
            _clock.Location = new Point(6, Window.ClientSize.Height - 24);

            _watch.Start();

            Timer timer = new Timer();
            timer.Start();
            // Runs every second.s
            timer.Tick += UpdateClock;

            // Setting flag counter visuals
            _remainingBombs = new Label();
            _remainingBombs.Parent = Window;
            _remainingBombs.BackColor = Color.Transparent;
            _remainingBombs.AutoSize = true;
            _remainingBombs.Font = new Font("Arial", 10, FontStyle.Bold);
            _remainingBombs.Location = new Point(Window.ClientSize.Width - 120, Window.ClientSize.Height - 24);
            _remainingBombs.Text = "Avaiable flags: " + bombCount.ToString();

            Window.Show();
        }

        /// <summary>
        /// Creates and displays end screen.
        /// Different views for winning condition and losing.
        /// Closes game window and on closing this window the whole application ends.
        /// </summary>
        /// <param name="winner"></param>
        public void EndScreen(bool winner) {
            View EndScreen = new View();
            EndScreen.Window.ClientSize = new Size(400, 200);
            // Shows information about game time on winning the game.
            if (winner) {
                EndScreen.Window.BackgroundImage = Properties.Resources.winner;
                Label time = new Label();
                time.Parent = EndScreen.Window;
                time.BackColor = Color.Transparent;
                time.Size = new Size(200, 60);
                time.TextAlign = ContentAlignment.BottomRight;
                time.Font = new Font("Arial", 40, FontStyle.Bold);
                time.ForeColor = Color.FromArgb(255, 216, 0);
                time.Location = new Point(154, 106);
                time.Text = _clock.Text.Remove(0, 13);
                // If time is too long to fit, show this instead.
                if (Int32.Parse(time.Text) >= 1000) {
                    time.Text = ">999";
                }
            } else {
                EndScreen.Window.BackgroundImage = Properties.Resources.game_over;
            }
            // Removing the callback to exit app.
            Window.FormClosed -= ExitApp;
            Window.Close();
            EndScreen.Window.StartPosition = FormStartPosition.CenterScreen;
            EndScreen.Window.Show();
        }
    }
}