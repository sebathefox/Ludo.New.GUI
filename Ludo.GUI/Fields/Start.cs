using Ludo.Base;
using Ludo.GUI.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.GUI.Fields
{
    class Start : Field
    {
        private readonly GameColor color;
        public Start(int id, int posX, int posY, GameColor color) : base(id, posX, posY)
        {
            this.Type = FieldType.StartField;
            this.color = color;
            this.Background = this.defaultImage = (ImageBrush)Draw.GetSpecialFieldImage(this);
        }

        public void Protec(ref Piece piece, ref Field field, ref Start fieldToMove, ref MovementController control, int dieValue)
        {
            Debug.WriteLine("Start was activated: " + this);

            if (piece.Color != fieldToMove.Color && fieldToMove.GetPieces.Count > 1)
            {
                control.KillPiece(ref piece);
                control.ResetField(field);
            }
            else
            {
                control.PlacePiece(piece, fieldToMove, PieceState.InPlay, dieValue);
                control.ResetField(field);
            }
        }

        public override GameColor Color => this.color;

        //TODO Make this class the startfield for the pieces
    }
}
