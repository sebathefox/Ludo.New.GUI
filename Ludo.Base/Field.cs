using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ludo.Base
{
    public enum FieldType { BaseField, SafeField, StartField, GlobeField, StarField, HomeField }

    public abstract class Field : Button
    {
        #region Fields

        protected List<IGamePiece> pieces = new List<IGamePiece>(2); // The pieces that are on the field
        protected ImageBrush defaultImage; // The field's default image (Used for when resetting the field)
        private Vector position; // The 2D position on the board

        #endregion

        protected Field(int id, int posX, int posY)
        {
            this.Id = id;
            this.Width = 32;
            this.Height = 32;
            this.position.X = (double) posX;
            this.position.Y = (double) posY;
        }

        protected Field(int id, Vector position)
        {
            this.Id = id;
            this.Width = 32;
            this.Height = 32;
            this.position = position;
        }
        
        // Removes the piece at the specified index
        public virtual void RemovePiece(IGamePiece index)
        {
            pieces.Remove(index);
        }
        
        // Adds a new piece to the list
        public virtual void AddPiece(IGamePiece piece)
        {
            this.GetPieces.Add(piece);
        }

        #region Getters/Setters

        public int Id { get; private set; }

        public FieldType Type { get; protected set; }

        public virtual GameColor Color { get; set; }

        public virtual Vector Position
        {
            get => position;
            set => position = value;
        }

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
