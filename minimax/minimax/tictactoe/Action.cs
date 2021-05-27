using System;
using System.Collections.Generic;
using System.Text;

namespace minimax.tictactoe
{
    class Action
    {
        public int row;
        public int col;

        public Action(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int Row
        {
            get { return row; }
        }

        public int Col
        {
            get { return col; }
        }
    }
}
