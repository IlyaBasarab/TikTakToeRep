using System;

namespace TikTakToe
{
    class HardLevel : Level
    {
        private Board board;



        public HardLevel(Board board)
        {
            this.board = board;
        }

        public override void MakeMove(Board board, int playerSymbol)
        {
            if (board.GetWinnerCell(1).elem == 3 && board.GetWinnerCell(playerSymbol).elem == 3) 
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
            else if (board.GetWinnerCell(1).elem == 0 && board.GetWinnerCell(playerSymbol).elem == 3)
            {
                board.SetElement(board.GetWinnerCell(1).rowIdx, board.GetWinnerCell(1).colIdx, playerSymbol);
            }

            else if (board.GetWinnerCell(1).elem == 3 && board.GetWinnerCell(playerSymbol).elem == 0)
            {
                board.SetElement(board.GetWinnerCell(playerSymbol).rowIdx, board.GetWinnerCell(playerSymbol).colIdx, playerSymbol);
            }
            else if (board.GetWinnerCell(1).elem == 0 && board.GetWinnerCell(playerSymbol).elem == 0)
            {
                board.SetElement(board.GetWinnerCell(playerSymbol).rowIdx, board.GetWinnerCell(playerSymbol).colIdx, playerSymbol);
            }


        }
    }
}

