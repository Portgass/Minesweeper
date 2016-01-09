using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    class Program {
        static void Main(string[] args) {

            // Minesweeper
            // Petr Svoboda, 1. ročník
            // Zimní semestr 2015/2016
            // Programování I - NPRG030

            MenuController mn = new MenuController();
            mn.StartMenu();
        }
    }
}
