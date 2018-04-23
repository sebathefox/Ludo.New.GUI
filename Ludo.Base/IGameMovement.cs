using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    public interface IGameMovement
    {
        bool IsPiecePlaced(Field field);

        void MovePiece(ref List<Field> fields, int pieceTurn, int dieRoll);

        void RemovePiece(ref Field field);

        void KillPiece(ref Piece piece);
    }
}
