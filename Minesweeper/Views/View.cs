using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper {
    class View {
        private Form _window;

        public Form Window {
            get { return _window; }
            set { _window = value; }
        }

        public View() {
            _window = new Form();
            _window.Text = "Minesweeper";
            _window.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
