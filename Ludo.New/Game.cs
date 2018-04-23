using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.New
{
    class Game
    {
        private Player[] players;
        private IGameField[] fields;
        private int numberOfPlayers;

        public Game()
        {
            SetNumberOfPlayers();
            CreatePlayers();
        }

        private void SetNumberOfPlayers()
        {
            while (numberOfPlayers < 2 || numberOfPlayers > 4)
            {
                if (!Int32.TryParse(Console.ReadLine(), out numberOfPlayers))
                {
                    Console.WriteLine("The number was either too high or too low");
                    Console.WriteLine("Please try again");
                }
            }
        }

        private void CreatePlayers()
        {

        }

        private void CreateFields()
        {

        }
    }
}
