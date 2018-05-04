using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Ludo.GUI.Controls;

namespace Ludo.GUI.Fields
{
    class Globe : Field
    {
        public Globe(int id, int posX, int posY) : base(id, posX, posY)
        {
            this.Type = FieldType.GlobeField;
            this.Background = this.defaultImage = (ImageBrush)FindResource("Globe");
            this.Color = GameColor.White;
        }

        public void Protec(ref Piece piece, ref Field field, ref Globe fieldToMove, ref MovementController control, int dieValue)
        {
            LogControl.Log("globe was activated: " + this, LogControl.LogLevel.Information);

            if (piece.Color != fieldToMove.Color && fieldToMove.Color != GameColor.White)
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

        public override GameColor Color { get; set; }
    }
}
