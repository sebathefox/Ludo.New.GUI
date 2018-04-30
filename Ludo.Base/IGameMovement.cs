using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    /// <summary>
    /// Controls the movement scheme that is used to move objects on the board
    /// </summary>
    public interface IGameMovement
    {
        /// <summary>
        /// Validates if the player can move any piece and handles accordingly
        /// </summary>
        void Turn();

        /// <summary>
        /// Changes the turn
        /// </summary>
        void ChangeTurn();

        /// <summary>
        /// Checks if there is any pieces at the specified field
        /// </summary>
        /// <param name="field">the field to search</param>
        /// <returns>True if any pieces otherwise false</returns>
        bool IsPiecePlaced(Field field);

        /// <summary>
        /// "Kills" the specified piece and resets its metadata
        /// </summary>
        /// <param name="piece">The piece to "kill"</param>
        void KillPiece(ref Piece piece);
    }
}
