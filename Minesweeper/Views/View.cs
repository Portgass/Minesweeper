using System;
using System.Windows.Forms;

namespace Minesweeper.Views {
    
    public class View {
        public Form Window { get; set; }
        
        public View() {
            Window = new Form
            {
                Text = "Minesweeper",
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false,
                MinimizeBox = false
            };
        }
    }
}
