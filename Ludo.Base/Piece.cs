using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    public class Piece : IGamePiece
    {

        private int position;

        public Piece(int id, GameColor color, int startPos)
        {
            this.Id = id;
            this.Color = color;
            this.State = PieceState.Home; //sets the default state to 'Home'
            this.StartPosition = this.position = startPos;
            this.CanMove = false;
            this.SetSafePosition();
        }

        private void SetSafePosition()
        {
            switch (this.Color)
            {
                case GameColor.Green:
                    GetSafePosition = 53;
                    break;
                case GameColor.Yellow:
                    GetSafePosition = 58;
                    break;
                case GameColor.Blue:
                    GetSafePosition = 63;
                    break;
                case GameColor.Red:
                    GetSafePosition = 68;
                    break;
                default:
                    throw new Exception("Unknown Error.");
            }
        }

        #region Properties

        /// <summary>
        /// Gets the id of the currently selected token
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the current color returned in GameColor (ReadOnly)
        /// </summary>
        public GameColor Color { get; private set; }

        /// <summary>
        /// Gets the current state returned in TokenState
        /// </summary>
        public PieceState State { get; set; }

        /// <summary>
        /// Gets the current position
        /// </summary>
        public void SetPosition(int position)
        {
            this.position = position;
        }

        /// <summary>
        /// Gets the piece's current position
        /// </summary>
        /// <returns>Returns the position as an int</returns>
        public int GetPosition() => this.position;

        /// <summary>
        /// Gets the safeposition as an int
        /// </summary>
        public int GetSafePosition { get; protected set; }
       
        /// <summary>
        /// Gets the startposition
        /// </summary>
        public int StartPosition { get; private set; }


        /// <summary>
        /// Gets and/or sets the baseposition
        /// </summary>
        public int BasePosition { get; set; }

        /// <summary>
        /// Count up to 52? then moves token to safe
        /// </summary>
        public int Counter { get; set; }

        /// <summary>
        /// If true the token can move else false
        /// </summary>
        public bool CanMove { get; set; }

        #endregion

        public override string ToString()
        {
            return "PieceId: " + Id + ", Color: " + Color + ", Position: " + position + ", CanMove: " + CanMove;
        }
    }
}
