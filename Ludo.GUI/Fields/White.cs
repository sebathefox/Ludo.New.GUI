using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.GUI.Fields
{
    class White : Field
    {
        public White(int id, int posX, int posY) : base(id, posX, posY)
        {
            this.Type = FieldType.BaseField;
            this.Background = (ImageBrush) FindResource("WhiteField");
        }


    }
}
