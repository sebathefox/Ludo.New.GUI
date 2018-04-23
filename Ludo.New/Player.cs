using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.New
{
    class Player : IGameMovement
    {
        private IGamePiece[] pieces;

        public Player()
        {

        }

        public bool IsPiecePlaced(IGameField field)
        {
            return field.IsEnemyPiece();
        }

        public void MovePiece(ref List<IGameField> fields, int pieceTurn, int dieRoll)
        {
            IGamePiece piece = GetPiece(pieceTurn);

            IGameField currentField = fields[piece.Position]; // Used so we can reset the earlier used position
            IGameField fieldToMove = fields[(piece.Position + dieRoll)];

            currentField.RemovePiece(piece);
        }

        public void RemovePiece(IGamePiece piece)
        {
            throw new NotImplementedException();
        }

        #region Properties
        public int Id { get; private set; }
        public string Name { get; set; }
        public IGamePiece[] GetPieces { get => this.pieces; private set => this.pieces = value; }
        public IGamePiece GetPiece(int index) => this.pieces[index];

        public void RemovePiece(ref IGameField field)
        {
            try
            {
                field.Color = GameColor.White;
            }
            catch (FieldAccessException e)
            {
                
            }
            
        }

        public void KillPiece(ref IGamePiece piece)
        {
            piece.Counter = 0;
            piece.Position = piece.HomePosition;
            piece.State = PieceState.Home;
        }

        #endregion
    }
}
