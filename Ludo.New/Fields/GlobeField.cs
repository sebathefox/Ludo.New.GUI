using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.New.Fields
{
    class GlobeField : Field
    {
        public GlobeField(int id) : base(id)
        {
            this.Type = FieldType.GlobeField;
        }
    }
}
