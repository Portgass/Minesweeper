using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {

    class ConsoleView {

        public void ShowBoard(Board board, Cursor cursor) {
            Console.Clear();
            for (int i = 0; i < board.Width; i++) {
                for (int j = 0; j < board.Height; j++) {
                    if ((i == cursor.YPosition) && (j == cursor.XPosition)) {
                        Console.Write("_");
                    } else {
                        Console.Write(board.TileArray[i, j].Value);
                    }
                }
                Console.WriteLine();
            }
        }

        public int GetProperty(string propertyName) {
            int property = 0;
            Console.WriteLine("Enter board " + propertyName + ":");
            property = Int32.Parse(Console.ReadLine());
            return property;
        }

        public string ReadKey() {
            string key = Console.ReadLine();
            return key;
        }

        public GameAction GetActionKey() {
            var ch = Console.ReadKey(false).Key;
            switch (ch) {
                case ConsoleKey.J:
                    return GameAction.MoveLeft;
                case ConsoleKey.L:
                    return GameAction.MoveRight;
                case ConsoleKey.K:
                    return GameAction.MoveDown;
                case ConsoleKey.I:
                    return GameAction.MoveUp;
                default:
                    return 0;
            }
        }
        
    }
}
