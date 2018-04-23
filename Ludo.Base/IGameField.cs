using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    
    public interface IGameField : IGameColor
    {
        bool IsEnemyPiece(); // Are there any enemy pieces?

        void RemovePiece(IGamePiece piece);

        int Id { get; }
        FieldType Type { get; } // Gets the type of the field

        List<IGamePiece> GetPieces { get; set; }
    }
}
