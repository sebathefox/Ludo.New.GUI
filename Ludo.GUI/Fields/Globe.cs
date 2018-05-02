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
        public Globe(int id, int posX, int posY) : base(id, posX, posY)
        {
            this.Type = FieldType.GlobeField;
            this.Background = this.defaultImage = (ImageBrush)FindResource("Globe");
            this.Color = GameColor.White;
        }

        public void Protec()
        {
            
        }

        public override GameColor Color { get; set; }
    }
}
