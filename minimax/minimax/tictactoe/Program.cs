using minimax.core.adversarial;
using System;
using System.Collections.Generic;
using System.Text;

namespace minimax.tictactoe
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            State state = game.GetInitialState();
            List<Action> availableActions = new List<Action>();

            AdversarialSearch<State, Action> adversarialSearch;


            Console.WriteLine("Inserisci il livello di difficoltà dell'avversario:");
            int.TryParse(Console.ReadLine(), out int livello);

            do
            {
                Console.WriteLine("Inserisci la mossa che vuoi fare: ([0 1] -> RIGA: 0 COLONNA: 1) ");
                string mossa = Console.ReadLine();
                string[] mosse = mossa.Split(' ');
                Action move = new Action(Convert.ToInt32(mosse[0]), Convert.ToInt32(mosse[1]));
            } while (!game.IsTerminal(state));
        }
        public static void PrintBoardState(State state)
        {
            char[] symbols = new char[3] { ' ', 'X', 'O' };
            int[] symbolSearch = new int[9];
            int c = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state.campo[i, j] == -1)
                    {
                        symbolSearch[c] = 0;
                    }
                    else if (state.campo[i, j] == 0)
                    {
                        symbolSearch[c] = 1;
                    }
                    else
                    {
                        symbolSearch[c] = 2;
                    }
                    c++;
                }
            }
            Console.WriteLine(  $"+---+---+---+\n" +
                                $"| {symbols[symbolSearch[0]]} | {symbols[symbolSearch[1]]} | {symbols[symbolSearch[2]]} |\n" +
                                $"+---+---+---+\n" +
                                $"| {symbols[symbolSearch[3]]} | {symbols[symbolSearch[4]]} | {symbols[symbolSearch[5]]} |\n" +
                                $"+---+---+---+\n" +
                                $"| {symbols[symbolSearch[6]]} | {symbols[symbolSearch[7]]} | {symbols[symbolSearch[8]]} |\n" +
                                $"+---+---+---+\n");
        }
    }
}
