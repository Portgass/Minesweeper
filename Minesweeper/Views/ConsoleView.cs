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
    }
}
