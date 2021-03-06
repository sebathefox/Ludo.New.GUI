﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    public enum GameColor { Green, Yellow, Blue, Red, White }

    public class Player
    {
        private readonly Piece[] pieces; //A array with the tokens the player uses in the game
        private readonly List<Field> playerFields;

        /// <summary>
        /// Creates a new Player object that can be used in the game
        /// </summary>
        public Player(string name, int playerId, Piece[] pieces, List<Field> fields)
        {
            this.Name = name;
            this.Id = playerId;
            this.pieces = pieces;
            this.playerFields = fields;

            // Populates the homefields with pieces
            for (int i = 0; i < 4; i++)
            {
                this.pieces[i].BasePosition = (this.playerFields[i].Id - 1);
                this.playerFields[i].AddPiece(this.pieces[i]);
            }
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
        /// Gets a list of the private fields of...
        /// </summary>
        public List<Field> GetPlayerFields { get => this.playerFields; }

        /// <summary>
        /// Indexer to get the player's pieces.
        /// </summary>
        /// <param name="index">The zero based index of the piece.</param>
        /// <returns>The piece if found otherwise null</returns>
        public Piece this[int index]
        {
            get
            {
                try
                {
                    return this.pieces[index];
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Index out of range exception while using the player indexer.");
                    return null;
                }
                
            }
        }

        #endregion

        public override string ToString()
        {
            return "ID: " + this.Id + " : PIECES: " + this.GetPieces().ToString();
        }
    }
}
