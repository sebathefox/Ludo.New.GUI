using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    public interface IGameMovement
    {
        bool IsPiecePlaced(IGameField field);

        void MovePiece(ref List<IGameField> fields, int pieceTurn, int dieRoll);

        void RemovePiece(ref IGameField field);

        void KillPiece(ref IGamePiece piece);
    }
}
