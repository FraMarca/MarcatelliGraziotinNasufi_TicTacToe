using System;
using System.Collections.Generic;
using System.Text;

namespace minimax.tictactoe
{
    class State
    {
        public const int EMPTY = -1;
        public const int CYRCLE = (int)Player.Circle;
        public const int CROSS = (int)Player.Cross;

        public int[,] campo { get; set; }
        public Player giocatoreCorrente { get; set; }

        public State()
        {
            campo = new int[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    campo[row, col] = EMPTY;
                }
            }

            giocatoreCorrente = Player.Cross;
        }

        public int GetBoardState(int row, int col)
        {
            if (campo[row, col] == EMPTY)
            {
                return EMPTY;
            }
            else if (campo[row, col] == CYRCLE)
            {
                return CYRCLE;
            }
            else
            {
                return CROSS;
            }
        }
    }
}
