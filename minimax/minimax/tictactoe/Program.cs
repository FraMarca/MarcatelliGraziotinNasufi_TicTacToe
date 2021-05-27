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
    }
}
