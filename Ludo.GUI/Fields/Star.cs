using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.GUI.Fields
{
    class Star : Field
    {
        private GameColor color;
        public Star(int id, int posX, int posY) : base(id, posX, posY)
        {
            this.Type = FieldType.StarField;
            this.Background = this.defaultImage = (ImageBrush)FindResource("DieOne");
            this.color = GameColor.White;
        }

        public override GameColor Color => this.Color;
        public GameColor SetColor { get => this.color; set => this.color = value; }
    }
}
