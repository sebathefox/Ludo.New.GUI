using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    public class Dice
    {
        public Dice()
        {
            this.Value = new Random().Next(1, 7);
        }

        public int Throw()
        {
            return this.Value = new Random().Next(1, 7);
        }

        public int Value { get; private set; }

        // TODO Implement imagestuffish...
    }
}
