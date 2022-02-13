using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class Visual
    {

        public Visual()
        { }

        public void ShowBoard(Board board)
        {

            for (int i = 0; i < board.GetRowCount(); i++)
            {
                for (int j = 0; j < board.GetColCount(); j++)
                {
                    int elem = board.GetElem(i, j);
                    char symbol = GetSymbol(elem);

                    Console.Write(symbol + "\t");

                }
                Console.WriteLine("");
            }

            Console.WriteLine("\n \n");

        }


       

        public char GetSymbol(int value)
        {
            if (value == 1)
                return 'X';
            else if (value == 2)
                return '0';
            return '_';
        }


    }
}
