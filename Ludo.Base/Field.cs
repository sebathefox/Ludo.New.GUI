using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ludo.Base
{
    public abstract class Field : Button
    {
        List<IGamePiece> pieces;

        protected Field(int id)
        {
            this.Id = Id;
            
        }

        public virtual bool IsEnemyPiece()
        {
            if (this.pieces.Count > 0)
                return true;
            return false;
        }

        public virtual void RemovePiece(IGamePiece index)
        {
            pieces.Remove(index);
        }

        public int Id { get; private set; }

        public FieldType Type { get; protected set; }

        public List<IGamePiece> GetPieces { get => this.pieces; set => this.pieces = value; }

        protected virtual GameColor Color { get; set; }

        public Bitmap Image { get; private set; }
    }
}
