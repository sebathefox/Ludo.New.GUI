using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.GUI.Fields
{
    class Globe : Field
    {
        private GameColor color;
        public Globe(int id, int posX, int posY) : base(id, posX, posY)
        {
            this.Type = FieldType.GlobeField;
            this.Background = this.defaultImage = (ImageBrush)FindResource("Globe");
            this.Color = GameColor.White;
        }

        public override GameColor Color { get; set; }
        public GameColor SetColor { private get => this.color; set => this.color = value; }
    }
}
