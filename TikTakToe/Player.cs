using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    abstract class Player
    {

        protected int playerSymbol;


        public Player( int symbol)
        {
            playerSymbol= symbol;
        }

        public int GetPlayer()
        {
            return playerSymbol;
        }

        public abstract void Move(Board board);

  }

    class HumanPlayer : Player
    {



        public HumanPlayer(int symbol) : base(symbol)
        {

        }



        public override void Move(Board board)
        {
            int rowInput = 0;
            int colInput = 0;

            int rowIdx = 0;
            int colIdx = 0;

            do
            {
                Console.WriteLine("Player "+ playerSymbol + " turn: \n");

                Console.WriteLine("Enter row [1;3]");
                rowInput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter col [1;3]");
                colInput = Convert.ToInt32(Console.ReadLine());


                rowIdx = rowInput - 1;
                colIdx = colInput - 1;


            } while (!board.IsEmpty(rowIdx, colIdx));

            board.SetElement(rowIdx, colIdx, playerSymbol);
        }



    }

    class CpuPlayer : Player
    {
        Level level = null;

        public CpuPlayer(Level level, int symbol) : base(symbol)
        {
            this.level = level;
        }


        public override void Move(Board board)
        {
            Console.WriteLine("Computer turn: \n");
            level.MakeMove(board, playerSymbol);



        }
    }




}
