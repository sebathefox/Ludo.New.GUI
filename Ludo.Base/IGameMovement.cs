using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.Base
{
    public delegate void Finished(object sender, Piece piece);

    //TODO: OPTIMIZE
    /// <summary>
    /// Controls the movement scheme that is used to move objects on the board
    /// </summary>
    public interface IGameMovement
    {
        void Move(ref Field field, ref List<Field> fields, ref Player player, int dieValue);

        void UpdateField(Field field, ImageBrush image);

        void ResetField(Field field);

        void PlacePiece(Piece piece, Field field, PieceState state, int dieValue);

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

        event Finished OnMove;
    }
}
