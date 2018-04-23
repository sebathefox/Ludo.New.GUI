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
        public White(int id) : base(id)
        {
            this.Type = FieldType.BaseField;
            this.Image = (ImageBrush) FindResource("WhiteField");
        }


    }
}
