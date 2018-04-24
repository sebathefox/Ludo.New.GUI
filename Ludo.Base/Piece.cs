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
        public event PieceMovedHandler OnMove;
        public Piece(int id, GameColor color, int startPos)
        {
            this.Id = id;
            this.Color = color;
            this.State = PieceState.Home; //sets the default state to 'Home'
            this.HomePosition = this.Position = startPos;
            this.CanMove = false;
        }

        public void MovePiece(ref List<Field> fields, int dieValue)
        {
            Field oldField = fields[this.Position];

            // TODO Make movement
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
        public int Position { get; set; }

        /// <summary>
        /// Gets the startposition
        /// </summary>
        public int HomePosition { get; private set; }

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
            return "PieceId: " + Id + ", Color: " + Color;
        }
    }
}
