using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class GameController
    {
        private MenuController mn;

        public GameController()
        {
            mn = new MenuController();
            mn.StartMenu();
        }

        void StartGame(object sender, EventArgs e)
        {
            var gm = new BoardController(mn.Difficulty, mn.GameMode);
            gm.InitializeGame();
            gm.Start();
        }
    }
}
