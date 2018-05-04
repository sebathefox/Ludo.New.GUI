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
    class Star : Field
    {
        private GameColor color;
        public Star(int id, int posX, int posY) : base(id, posX, posY)
        {
            this.Type = FieldType.StarField;
            this.Background = this.defaultImage = (ImageBrush)FindResource("Star");
            this.color = GameColor.White;
        }

        public void Protec(ref Piece piece, ref Field field, ref MovementController control)
        {
            LogControl.Log("Star was activated: " + this, LogControl.LogLevel.Information);
            List<Field> fields = control.Fields;

            Piece piece1 = piece;
            Field starField = fields.Find(fld => fld.Type == FieldType.StarField && fld.Id > piece1.GetPosition() + 2);

            control.PlacePiece(piece, starField, PieceState.InPlay, starField.Id - piece.GetPosition());
            control.ResetField(field);
        }

        public override GameColor Color => this.Color;
        public GameColor SetColor { get => this.color; set => this.color = value; }
    }
}
