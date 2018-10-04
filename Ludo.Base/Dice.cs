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
            // Initializes a new random value
            this.Value = new Random().Next(1, 7);
        }

        /// <summary>
        ///  Throws the die to get a new value
        /// </summary>
        /// <returns>The value</returns>
        public int Throw()
        {
            return this.Value = new Random().Next(1, 7);
        }

        /// <summary>
        /// Get the value of the dice
        /// </summary>
        public int Value { get; private set; }
    }
}
