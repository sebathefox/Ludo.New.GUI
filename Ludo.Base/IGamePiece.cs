using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    public enum PieceState { Home, InPlay, Safe, Finished }

    public interface IGamePiece
    {
        /// <summary>
        /// Gets the id of the currently selected token
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the current color returned in GameColor (ReadOnly)
        /// </summary>
        GameColor Color { get; }

        /// <summary>
        /// Gets the current state returned in TokenState
        /// </summary>
        PieceState State { get; set; }

        /// <summary>
        /// Gets the current position
        /// </summary>
        void SetPosition(int position);

        /// <summary>
        /// Gets the piece's current position
        /// </summary>
        /// <returns>Returns the position as an int</returns>
        int GetPosition();

        //TODO: add to player instead (cause: DRY-principles)
        /// <summary>
        /// Gets the startposition
        /// </summary>
        int StartPosition { get; }

        /// <summary>
        /// Count up to 52? then moves token to safe
        /// </summary>
        int Counter { get; set; }

        /// <summary>
        /// If true the token can move else false
        /// </summary>
        bool CanMove { get; set; }
    }
}