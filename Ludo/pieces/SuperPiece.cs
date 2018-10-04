using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludo.Base;

namespace Ludo.pieces
{
    class SuperPiece : IGamePiece
    {
        public int Id { get; }
        public GameColor Color { get; }
        public PieceState State { get; set; }
        public void SetPosition(int position)
        {
            throw new NotImplementedException();
        }

        public int GetPosition()
        {
            throw new NotImplementedException();
        }

        public int StartPosition { get; }
        public int Counter { get; set; }
        public bool CanMove { get; set; }
    }
}
