using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludo.Base;

namespace Ludo.New.Fields
{
    class StarField : Field
    {
        public StarField(int id) : base(id)
        {
            this.Type = FieldType.StarField;
        }
    }
}
