using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    public enum GameColor { Red, Blue, Green, Yellow, White}

    public interface IGameColor
    {
        GameColor Color { get; set; }
    }
}
