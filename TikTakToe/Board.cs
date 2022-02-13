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

        public bool IsBoardFull()
        {
            try
            {
                for (int i = 0; i < GetRowCount(); i++)
                {
                    for (int j = 0; j < GetColCount(); j++)
                    {
                        if (IsEmpty(i, j))
                            return false;
                    }
                }
                
                return true;
            }
            catch (ArgumentException ex)
            { }
            return true;


        }

        public int WinnerCheck()
        {

            try
            {
                
                for (int i = 0; i < GetRowCount(); i++)
                {
                    if (GetElem(0, i) == GetElem(1, i) && GetElem(1, i) == GetElem(2, i))
                    {
                        return GetElem(1, i);
                    }


                    else if (GetElem(i, 0) == GetElem(i, 1) && GetElem(i, 1) == GetElem(i, 2))
                    {
                        return GetElem(i, 1);
                    }
                }

               if (GetElem(0, 0) == GetElem(1, 1) && GetElem(1, 1) == GetElem(2, 2))
                {
                    return GetElem(0, 0);
                }


                else if (GetElem(2, 0) == GetElem(1, 1) && GetElem(1, 1) == GetElem(0, 2))
                {
                    return GetElem(2, 1);
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

                for (int i = 0; i < GetRowCount(); i++)
                {
                    row[0] = board[i, 0];
                    row[1] = board[i, 1];
                    row[2] = board[i, 2];
                    Array.Sort(row, new CellComp());
                    if (row[0].elem == 0 && row[1].elem == winnerPlayer && row[2].elem == winnerPlayer)
                        return row[0];
                }

                for(int j =0; j< GetColCount(); j++)
                { 
                    col[0] = board[0, j];
                    col[1] = board[1, j];
                    col[2] = board[2, j];
                    Array.Sort(col, new CellComp());
                    if (col[0].elem == 0 && col[1].elem == winnerPlayer && col[2].elem == winnerPlayer)
                        return col[0];
                }

                line1[0] = board[0, 0];
                        line1[1] = board[1, 1];
                        line1[2] = board[2, 2];
                Array.Sort(line1, new CellComp());
                        if (line1[0].elem == 0 && line1[1].elem == winnerPlayer && line1[2].elem == winnerPlayer)
                            return line1[0];

                        line2[0] = board[2,0];
                        line2[1] = board[1, 1];
                        line2[2] = board[0, 2];
                        Array.Sort(line2, new CellComp());
                        if (line2[0].elem == 0 && line2[1].elem == winnerPlayer && line2[2].elem == winnerPlayer)
                            return line2[0];

    
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
