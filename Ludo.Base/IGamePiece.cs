using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    public enum PieceState { Home, InPlay, Safe, Finished }

    public delegate void PieceMovedHandler(IGamePiece piece);

    public interface IGamePiece
    {
        int Id { get; }

        GameColor Color { get; }

        PieceState State { get; set; }

        void SetPosition(int position);

        int GetPosition();

        int StartPosition { get; }

        int Counter { get; set; }

        bool CanMove { get; set; }

        event PieceMovedHandler OnMove;
    }
}