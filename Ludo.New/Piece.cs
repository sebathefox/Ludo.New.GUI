using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.New
{
    public class Piece : IGamePiece
    {
        public Piece(int id, GameColor color)
        {
            this.Id = id;
            this.Color = color;
        }

        public int Id { get; private set; }

        public int Position { get; set; }


        public int HomePosition { get; private set; }

        public int Counter { get; set; }

        public PieceState State { get; set; }

        public GameColor Color { get; private set; }
    }
}
