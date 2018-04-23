using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludo.Base;

namespace Ludo.New.Fields
{
    class SafeField : Field
    {
        public SafeField(int id) : base(id)
        {
            this.Type = FieldType.SafeField;
        }

        public override GameColor Color { get;  set; }
    }
}
