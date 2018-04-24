using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ludo.Base
{
    public enum FieldType { BaseField, SafeField, StartField, GlobeField, StarField, HomeField }

    public abstract class Field : Button
    {
        private List<IGamePiece> pieces;

        protected Field(int id, int posX, int posY)
        {
            this.Id = id;
            this.Width = 32;
            this.Height = 32;
            this.PosX = posX;
            this.PosY = posY;
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

        public virtual int PosX { get; set; }
        public virtual int PosY { get; set; }
    }
}
