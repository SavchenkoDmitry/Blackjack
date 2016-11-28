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
            Player player = new Player();
            while (true)
            {
                player.PlayTheGame();
                System.Console.WriteLine("________________________________________________________\n");
            }
        }
    }
}
