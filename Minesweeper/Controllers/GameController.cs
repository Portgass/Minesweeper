using System;
using System.Windows.Forms;
using Minesweeper.Models;

namespace Minesweeper.Controllers
{
    public class GameController
    {
        
        private BoardController BoardControl { get; set; }

        public GameController()
        {
            var board = new Board(new Coordinates(20, 20));
        }

        public void Start()
        {
            Application.Run();
        }
    }
}
