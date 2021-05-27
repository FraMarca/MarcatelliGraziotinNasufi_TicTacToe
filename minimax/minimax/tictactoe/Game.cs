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
            List<Action> action = new List<Action>();
            Action tmp;
            int[,] campo = state.campo;
            Player giocatoreCorrente = state.giocatoreCorrente;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (campo[row, col] == -1)
                    {
                        tmp = new Action(row, col);
                        action.Add(tmp);
                    }
                }
            }
            return action;
        }

        public State GetInitialState()
        {
            State state = new State();

            int[,] campo = new int[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    campo[row, col] = -1;
                }
            }

            Player giocatoreCorrente = Player.Cross;

            return state;
        }

        public Player GetPlayer(State state)
        {
            return state.giocatoreCorrente;
        }

        public Player[] GetPlayers()
        {
            Player[] players = new Player[2] { Player.Cross, Player.Circle };
            return players;
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
            int winner = ControllaVincitore(state);
            if (IsTerminal(state))
            {
                if (winner == (int)player)
                {
                    return double.PositiveInfinity - 1;
                }
                else if (winner == -1)
                {
                    return 0;
                }
                else
                {
                    return double.NegativeInfinity + 1;
                }
            }

            if (state.GetBoardState(1, 1) == (int)player)
            {
                return 2;
            }
            else if (state.GetBoardState(1, 1) != (int)player && state.GetBoardState(1, 1) != -1)
            {
                return -2;
            }

            //for (int i = 0; i < 3; i++)
            //{
            //    if (state.campo[i, 0] != -1)
            //    {
            //        if ((state.GetBoardState(i, 0) == (int)player && state.GetBoardState(i, 1) == (int)player) || (state.GetBoardState(i, 1) == (int)player && state.GetBoardState(i, 2) == (int)player))
            //        {
            //            return 7;
            //        }
            //        else if ((state.GetBoardState(i, 0) != (int)player && state.GetBoardState(i, 0) != -1) || (state.GetBoardState(i, 2) != (int)player && state.GetBoardState(i, 2) != -1))
            //        {
            //            return -7;
            //        }
            //    }
            //    if (state.campo[0, i] != -1)
            //    {
            //        if ((state.GetBoardState(0, i) == (int)player && state.GetBoardState(1, i) == (int)player) || (state.GetBoardState(1, i) == (int)player && state.GetBoardState(2, i) == (int)player))
            //        {
            //            return 7;
            //        }
            //        else if ((state.GetBoardState(0, i) != (int)player && state.GetBoardState(0, i) != -1) || (state.GetBoardState(2, i) != (int)player && state.GetBoardState(2, i) != -1))
            //        {
            //            return -7;
            //        }
            //    }
            //}
            return 0;
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
