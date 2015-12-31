using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class Program {
        static void Main(string[] args) {
            MenuController mn = new MenuController();
            mn.StartMenu();
            GameController gm = new GameController(mn.Difficulty);
            gm.InitializeGame();
            gm.Update();
        }
    }
}
