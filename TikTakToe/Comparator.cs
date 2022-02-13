using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
     class CellComp : IComparer<Cell>
        {
            public int Compare(Cell c1, Cell c2)
            {return c1.elem - c2.elem;
                
            }
        }
       

    
}
