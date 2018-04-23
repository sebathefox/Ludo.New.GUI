using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    public class Player
    {
        private readonly Piece[] pieces; //A array with the tokens the player uses in the game

        /// <summary>
        /// Creates a new Player object that can be used in the game
        /// </summary>
        public Player(string name, int playerId, Piece[] pieces)
        {
            this.Name = name;
            this.Id = playerId;
            this.pieces = pieces;
        }

        #region Properties/GetterMethods

        /// <summary>
        /// Gets the id of the player object
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name of the player object
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the color of the player object
        /// </summary>
        public GameColor Color { get => this.pieces[0].Color; }

        /// <summary>
        /// Gets the array with the players tokens
        /// </summary>
        public Piece[] GetPieces() => this.pieces;

        /// <summary>
        /// Gets a single array from the token array
        /// </summary>
        public Piece GetPiece(int pieceId) => this.pieces[pieceId];

        #endregion
    }
}
