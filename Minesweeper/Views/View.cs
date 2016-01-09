using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {

    /// <summary>
    /// Core of the game representation using Windows Forms.
    /// </summary>
    class View {
        private Form _window;

        public Form Window {
            get { return _window; }
            set { _window = value; }
        }

        /// <summary>
        /// Sets basic parameters that will apply to all game windows.
        /// Adds callback to handle window closing.
        /// </summary>
        public View() {
            _window = new Form();
            _window.Text = "Minesweeper";
            _window.StartPosition = FormStartPosition.CenterScreen;
            _window.FormBorderStyle = FormBorderStyle.FixedSingle;
            _window.MaximizeBox = false;
            _window.MinimizeBox = false;
            _window.FormClosed += ExitApp;
        }


        /// <summary>
        /// Closes the whole app.
        /// !Remove the callback before changing views.
        /// Maybe there is better method. For example with custom exit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ExitApp(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
