using Ludo.Base;
using Ludo.GUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.GUI.Fields
{
    class Safe : Field
    {
        private readonly GameColor color;
        public Safe(int id, int posX, int posY, GameColor color) : base(id, posX, posY)
        {
            this.Type = FieldType.SafeField;
            this.color = color;
            this.Background = this.defaultImage = (ImageBrush)Draw.GetFieldImage(this);
        }

        public override GameColor Color { get => this.color;}
    }
}
