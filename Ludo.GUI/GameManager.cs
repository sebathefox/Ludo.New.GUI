using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludo.Base;

namespace Ludo.GUI
{
    public static class GameManager
    {
        private static List<Player> players = new List<Player>(4);

        public static void AddPlayer(int playerId, string name)
        {
            
            Piece[] pieces = new Piece[4];

            for(int id = 1; id <= 4; id++)
            {
                pieces[(id -1)] = new Piece(id, SetColor(playerId), SetStartPosition(playerId));
            }

            players.Add(new Player(name, playerId, pieces));
        }

        private static GameColor SetColor(int index)
        {
            switch(index)
            {
                case 1:
                    return GameColor.Blue;
                case 2:
                    return GameColor.Green;
                case 3:
                    return GameColor.Red;
                case 4:
                    return GameColor.Yellow;
            }
            throw new ArgumentException("ERROR: Wrong Parameter, ERRORCODE: 25565");
        }

        private static int SetStartPosition(int index)
        {
            switch (index)
            {
                case 1:
                    return 1;
                case 2:
                    return 14;
                case 3:
                    return 27;
                case 4:
                    return 40;
            }
            throw new ArgumentException("ERROR: Wrong Parameter, ERRORCODE: 25566");
        }

        public static List<Player> Players { get => players; private set => players = value; }
    }
}
