using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class EasyLevel : Level
    {
        private Board board;
        
        public EasyLevel(Board board)
        {
            board = board;
        }

        public override void MakeMove( Board board, int playerSymbol)
        {
            int rowIdx = 0;
            int colIdx = 0;

            Random random = new Random();
            
            do
            {
                rowIdx = random.Next(0, 3);
                colIdx = random.Next(0, 3);


            } while (!board.IsEmpty(rowIdx, colIdx));

            board.SetElement(rowIdx, colIdx, playerSymbol);
        }
    }
}
