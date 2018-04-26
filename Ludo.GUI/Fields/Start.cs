using Ludo.Base;
using System;
using System.Collections.Generic;
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
            this.Background = this.defaultImage = (ImageBrush)FindResource("DieSix");
            this.color = color;
        }

        public override GameColor Color => this.color;

        //TODO Make this class the startfield for the pieces
    }
}
