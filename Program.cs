using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    class Program
    {
        static void Main()
        {
            BlackjackTextView textVeiw = new BlackjackTextView(System.Console.In, System.Console.Out);
            GameSession gameSession = new GameSession(textVeiw);
            gameSession.RunGameLoop();
        }
    }
}
