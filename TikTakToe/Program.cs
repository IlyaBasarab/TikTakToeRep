using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class Board
    {
        private int[,] board = new int[3,3];

        public void SetElement(int row, int col,int element)
        {
            try
            {
                board[row, col] = element;
            }
            catch (ArgumentException ex)
            { 
                Console.WriteLine(ex.Message); 
            }
        }

        public int GetElem(int row, int col)
        {
            try
            {
                return board[row, col];
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }

        public int GetRowCount()
        {
            try
            { 
                return board.GetLength(0);
            }
            catch(Exception ex) { return 0; }
        }

        public int GetColCount()
        {
            try
            {
                return board.GetLength(1);
            }
            catch(Exception ex) { return 0; }
        }


        public bool IsEmpty(int row, int col)
        {
            try 
            { 
                return board[row, col] == 0; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); 
                return false;                
            }
            
        }
        public Board()
        {

        }
 }



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
                    char symbol = GetSimbol(elem);

                    Console.Write(symbol + "\t");

                }
                Console.WriteLine("");
            }
        }


        public bool IsBoardFull(Board board)
        {
            try
            {
                for (int i = 0; i < board.GetRowCount() - 1; i++)
                {
                    for (int j = 0; j < board.GetColCount() - 1; j++)
                    {
                        if (board.IsEmpty(i, j))
                            return false;
                    }
                }
                Console.WriteLine("Draw!");
                return true;
            }
            catch(ArgumentException ex)
            {}
            return true;


        }

        public char GetSimbol(int value)
        {
            if (value == 1)
                return 'X';
            else if (value == 2)
                return '0';
            return '_';
        }


    }


    class Player
    {
        private int playerSymbol;

        public Player(int symbol)
        {
            this.playerSymbol = symbol;
        }

        public int GetPlayer()
        {
            return playerSymbol;
        }

        public void Move(Board board)
        {
            int rowInput = 0;
            int colInput = 0;

            int rowIdx = 0;
            int colIdx = 0;

            do
            {
                Console.WriteLine("Enter row [1;3]");
                rowInput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter col [1;3]");
                colInput = Convert.ToInt32(Console.ReadLine());


                rowIdx = rowInput - 1;
                colIdx = colInput - 1;


            } while (!board.IsEmpty(rowIdx,colIdx));

            board.SetElement(rowIdx, colIdx, playerSymbol);
        }



    }




    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();
            game.Start();

        }
    }
}
