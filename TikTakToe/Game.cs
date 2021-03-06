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
            board.EmptyCellsBoard();

            Console.WriteLine("Choose your game: \n"
                +"1.player vs player \n"
                +"2.player vs computer \n");
            int value = Convert.ToInt32(Console.ReadLine());

            player1 = new HumanPlayer(1);

            if (value == 1)
                player2 = new HumanPlayer(2);
            else if (value == 2)
            {
                Console.WriteLine("Choose youre level: \n"
                    + "1.Easy \n"
                    + "2.Medium \n"
                    + "3.Hard \n");
                int levelValue = Convert.ToInt32(Console.ReadLine());
                if(levelValue == 1)
                {
                    Console.WriteLine("Easy level.");
                    player2 = new CpuPlayer(new EasyLevel(board), 2);
                }
                    

                else if(levelValue == 2)
                {
                    Console.WriteLine("Medium level.");
                    player2 = new CpuPlayer(new MediumLevel(board), 2);
                }
                    

                else if(levelValue == 3)
                {
                    Console.WriteLine("Hard level.");
                    player2 = new CpuPlayer(new HardLevel(board), 2);
                }
                   
            }
            

            bool player1Turn = true;

            while (!IsGameOver())
            {
                if (player1Turn)
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

        public bool IsGameOver()
        {


                if (board.WinnerCheck() != 0)
                {
                    int playerWinner = board.WinnerCheck();
                    Console.WriteLine("Player " + visual.GetSymbol(playerWinner) + " wins!");

                    return true;
                }

                if (board.IsBoardFull())
                {
                    Console.WriteLine("Draw");
                    return true;
                }

                return false;
            }


        





    }
}
