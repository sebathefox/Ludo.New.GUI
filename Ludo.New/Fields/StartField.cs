using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.New.Fields
{
    class StartField : Field
    {
        public StartField(int id, GameColor color) : base(id)
        {
            this.Type = FieldType.StartField;
            this.Color = color;
        }
    }
}
