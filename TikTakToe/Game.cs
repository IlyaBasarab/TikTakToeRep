using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class Game
    {
        private Board board = new Board();
        private Visual visual = new Visual();

        private Player player1 = null;
        private Player player2 = null;

        public Game()
        {
            
        }


        public void Start()
        {

            player1 = new Player(1);
            player2 = new Player(2);

            bool player1Turn = true;

            while(!IsGemeOver()&& !visual.IsBoardFull(board))
            {
                if(player1Turn)
                {
                    player1.Move(board);
                }
                else
                {
                    player2.Move(board);
                }

                visual.ShowBoard(board);
                player1Turn = !player1Turn;

            }
            

        }

        public bool IsGemeOver()
        {
            int element = WinnerCheck();

            if (element == 0)
                return false;
            else if (element == 1)
            {
                Console.WriteLine(" '\n'_________ " + visual.GetSimbol( player1.GetPlayer())+ "   wins!   __________________________");
                return true;
            }
            else if (element == 2)
            {
                Console.WriteLine(" \n _________" + visual.GetSimbol( player2.GetPlayer()) + "  wins!   ______________________");
                return true;
            }

            return false;
        }

        public int WinnerCheck()
        {

            try
            {
                for (int i = 0; i < board.GetRowCount() - 2; i++)
                {

                    for (int j = 0; j <= board.GetColCount() - 2; j++)
                    {
                        while (!board.IsEmpty(i, j))
                        {
                            if (board.GetElem(i, j) == board.GetElem(i + 1, j) && board.GetElem(i + 1, j) == board.GetElem(i + 2, j))
                                return board.GetElem(i, j);

                            else if (board.GetElem(i, j) == board.GetElem(i, j + 1) && board.GetElem(i, j + 1) == board.GetElem(i, j + 2))
                                return board.GetElem(i, j);

                            else if (board.GetElem(i, j) == board.GetElem(i + 1, j + 1) && board.GetElem(i + 1, j + 1) == board.GetElem(i + 2, j + 2))
                                return board.GetElem(i, j);

                            else if (board.GetElem(i+2, j) == board.GetElem(i + 1, j + 1) && board.GetElem(i + 1, j + 1) == board.GetElem(i, j + 2))
                                return board.GetElem(i, j);

                            return 0;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }

            return 0;
        }



    }
}
