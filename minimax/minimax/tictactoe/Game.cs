using minimax.core.adversarial;
using System;
using System.Collections.Generic;
using System.Text;

namespace minimax.tictactoe
{
    class Game : IGame<State, Action, Player>
    {
        public List<Action> GetActions(State state)
        {
            throw new NotImplementedException();
        }

        public State GetInitialState()
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer(State state)
        {
            throw new NotImplementedException();
        }

        public Player[] GetPlayers()
        {
            throw new NotImplementedException();
        }

        public State GetResult(State state, Action action)
        {
            //NUOVO STATO COPIA
            State copyState = new State();
            copyState.campo = (int[,])state.campo.Clone();
            copyState.giocatoreCorrente = state.giocatoreCorrente;

            //ASSEGNARE LA MOSSA
            copyState.campo[action.Row, action.Col] = (int)copyState.giocatoreCorrente;

            //INVERSIONE DEI PLAYER CORRENTI
            if (copyState.giocatoreCorrente == Player.Circle)

                copyState.giocatoreCorrente = Player.Cross;
            else
                copyState.giocatoreCorrente = Player.Circle;

            return copyState;
        }

        public double GetUtility(State state, Player player)
        {
            throw new NotImplementedException();
        }

        public bool IsTerminal(State state)
        {
            if (ControllaVincitore(state) != -1)
            {
                return true;
            }
            //CONTROLLO BOARD PIENA
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state.campo[i, j] == -1)
                    {
                        return false;
                    }
                }
            }

            return true;

        } 

        public int ControllaVincitore(State state)
        {
            //CONTROLLO RIGHE
            for (int i = 0; i < 3; i++)
            {
                if (state.campo[i, 0] != -1)
                {
                    if ((state.campo[i, 0] == state.campo[i, 1]) && (state.campo[i, 0] == state.campo[i, 2]))
                    {
                        return state.GetBoardState(i, 0);
                    }
                }
                if (state.campo[0, i] != -1)
                {
                    if ((state.campo[0, i] == state.campo[1, i]) && (state.campo[0, i] == state.campo[2, i]))
                    {
                        return state.GetBoardState(0, i);
                    }
                }
            }

            //CONTROLLO DIAGONALI
            if (state.campo[1, 1] != -1)
            {
                if ((state.campo[0, 0] == state.campo[1, 1]) && (state.campo[1, 1] == state.campo[2, 2]))
                {
                    return state.GetBoardState(1, 1);
                }
                else if ((state.campo[0, 2] == state.campo[1, 1]) && (state.campo[1, 1] == state.campo[2, 0]))
                {
                    return state.GetBoardState(1, 1);
                }
            }
            return -1;
        } 
    }
}
