using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class Board
    {
        Cell[,] board = new Cell[3,3];

        public void EmptyCellsBoard()
        {
            for (int i = 0; i < GetRowCount(); i++)
            {
                for (int j = 0; j < GetColCount(); j++)
                {
                    board[i, j] = new Cell(i, j, 0);
                }
            }
        }
        
        public void SetElement(int row, int col, int element)
        {
            try
            {
                board[row, col].rowIdx = row;
                board[row, col].colIdx = col;
                board[row,col].elem=element;
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
                return board[row, col].elem;
            }
            catch (NullReferenceException ex)
            {
                return 0;
            }
        }

        public int GetRowCount()
        {
            try
            {
                return board.GetLength(0);
            }
            catch (Exception ex) { return 0; }
        }

        public int GetColCount()
        {
            try
            {
                return board.GetLength(1);
            }
            catch (Exception ex) { return 0; }
        }

        public bool IsEmpty(int row, int col)
        {
            try
            {
                return board[row, col].elem == 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public int WinnerCheck()
        {

            try
            {
                int drawCount = 0;
                for (int i = 0; i < GetRowCount(); i++)
                {

                    for (int j = 0; j <= GetColCount(); j++)
                    {
                        do
                        {

                            if (GetElem(i, j) == GetElem(i + 1, j) && GetElem(i + 1, j) == GetElem(i + 2, j))
                                return GetElem(i, j);

                            else if (GetElem(i, j) == GetElem(i, j + 1) && GetElem(i, j + 1) == GetElem(i, j + 2))
                                return GetElem(i, j);

                            else if (GetElem(i, j) == GetElem(i + 1, j + 1) && GetElem(i + 1, j + 1) == GetElem(i + 2, j + 2))
                                return GetElem(i, j);

                            else if (GetElem(i + 2, j) == GetElem(i + 1, j + 1) && GetElem(i + 1, j + 1) == GetElem(i, j + 2))
                                return GetElem(i + 2, j);
                            
                            return 0;
                        }
                        while (!IsEmpty(i,j));
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

        public Cell GetWinnerCell(int winnerPlayer)
        {
            try
            {
                Cell[] row = new Cell[3];
                Cell[] col = new Cell[3];
                Cell[] line1 = new Cell[3];
                Cell[] line2 = new Cell[3];

                for (int i = 0; i < board.GetLength(0); i++)
                {

                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        
                        row[0] = board[i, j];
                        row[1] = board[i, j + 1];
                        row[2] = board[i, j + 2];
                        Array.Sort( row ,new CellComp()) ;
                        if (row[0].elem == 0  && row[1].elem == winnerPlayer && row[2].elem == winnerPlayer)
                            return row[0];

                        col[0] = board[i, j];
                        col[1] = board[i + 1, j];
                        col[2] = board[i + 2, j];
                        Array.Sort(col, new CellComp());
                        if (col[0].elem == 0 && col[1].elem == winnerPlayer && col[2].elem == winnerPlayer)
                            return col[0];

                        line1[0] = board[i, j];
                        line1[1] = board[i + 1, j + 1];
                        line1[2] = board[i + 2, j + 2];
                        Array.Sort(line1, new CellComp());
                        if (line1[0].elem == 0 && line1[1].elem == winnerPlayer && line1[2].elem == winnerPlayer)
                            return line1[0];

                        line2[0] = board[i + 2, j];
                        line2[1] = board[i + 1, j + 1];
                        line2[2] = board[i, j + 2];
                        Array.Sort(line2, new CellComp());
                        if (line2[0].elem == 0 && line2[1].elem == winnerPlayer && line2[2].elem == winnerPlayer)
                            return line2[0];


                    }
                }
                return null;

            }
            catch(Exception ex)
            {
                return null; 
            }



        }

        


        public Board()
        {

        }
    }
}
