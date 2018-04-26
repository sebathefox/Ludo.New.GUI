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
        bool IsPiecePlaced(Field field);

        void MovePiece(ref List<Field> fields, int pieceTurn, int dieRoll);

        void RemovePiece(ref Field field, ref IGamePiece piece);

        void KillPiece(ref Piece piece);

        List<Field> GetNextFields(IGamePiece piece, int dieValue);

        Field GetNextField(IGamePiece piece);
    }
}
