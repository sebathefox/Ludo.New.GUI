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
        #region Fields

        protected List<IGamePiece> pieces = new List<IGamePiece>(1); // The pieces that are on the field
        protected ImageBrush defaultImage; // The field's default image (Used for when resetting the field)

        #endregion

        protected Field(int id, int posX, int posY)
        {
            this.Id = id;
            this.Width = 32;
            this.Height = 32;
            this.PosX = posX;
            this.PosY = posY;
        }
        
        // Removes the piece at the specified index
        public virtual void RemovePiece(IGamePiece index)
        {
            pieces.Remove(index);
        }
        
        // Adds a new piece to the list
        public virtual void AddPiece(IGamePiece piece)
        {
            this.pieces.Add(piece);
        }

        #region Getters/Setters

        public int Id { get; private set; }

        public FieldType Type { get; protected set; }

        public virtual GameColor Color { get; set; }

        public virtual int PosX { get; set; }

        public virtual int PosY { get; set; }

        public virtual void SetDefaultImage()
        {
            this.Background = this.defaultImage;
        }

        public virtual ImageBrush GetDefaultImage()
        {
            return this.defaultImage;
        }

        public List<IGamePiece> GetPieces { get => this.pieces; set => this.pieces = value; }

        #endregion


        /// <summary>Returns the string representation of a <see cref="T:System.Windows.Controls.Control" /> object. </summary>
        /// <returns>A string that represents the control.</returns>
        public override string ToString()
        {
            return "Pieces: " + this.GetPieces.Count + ", Id" + this.Id;
        }
    }
}
