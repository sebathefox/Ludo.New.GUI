using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.New
{
    public enum PieceState { Home, InPlay, Finished }
    public class Piece : IGameColor
    {
        public Piece()
        {

        }

        public void MovePiece(ref IGameField currentField, ref IGameField fieldToMove)
        {
            // TODO Implement movement
        }

        public int Id { get; private set; }
        public GameColor Color { get; set; }
    }
}
