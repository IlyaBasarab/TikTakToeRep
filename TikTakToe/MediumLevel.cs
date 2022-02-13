using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class MediumLevel : Level
    {
        private Board board;



        public MediumLevel(Board board)
        {
            this.board = board;
        }

        public override void MakeMove(Board board, int playerSymbol)
        {
            
            
            if (board.GetWinnerCell(1)==null)
            {
                int rowIdx = 0;
                int colIdx = 0;

                Random random = new Random();

                do
                {
                    rowIdx = random.Next(0, 3);
                    colIdx = random.Next(0, 3);
                }
                while (!board.IsEmpty(rowIdx, colIdx));
                board.SetElement(rowIdx, colIdx, playerSymbol);

                
            }
            else
            {
                
                board.SetElement(board.GetWinnerCell(1).rowIdx, board.GetWinnerCell(1).colIdx, playerSymbol);

            }
            




        }
    }
}
