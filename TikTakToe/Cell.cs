using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class Cell
    {
        public int rowIdx;
        public int colIdx;
        public int elem;

        public Cell(int rowIdx, int colIdx, int elem)
        {
            this.rowIdx = rowIdx;
            this.colIdx = colIdx;
            this.elem = elem;
        }

        public override string ToString()
        {
            return "["+rowIdx +","+colIdx +"]= " +elem + '\n';
        }
    }
}
