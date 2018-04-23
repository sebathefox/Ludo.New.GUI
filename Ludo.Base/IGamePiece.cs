using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    public enum PieceState { Home, InPlay, Safe, Finished }

    public interface IGamePiece : IGameColor
    {
        int Id { get; }
        int Position { get; set; }
        int HomePosition { get; }
        int Counter { get; set; }

        PieceState State { get; set; }
    }
}