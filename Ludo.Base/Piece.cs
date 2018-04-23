using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    class Piece
    {
        public Piece(int id, GameColor color, int startPos)
        {
            this.Id = id;
            this.Color = color;
            this.State = PieceState.Home; //sets the default state to 'Home'
            this.StartPosition = this.Position = startPos;
            this.CanMove = false;
        }

        public void MoveToken(ref Field[] fields, int dieValue)
        {
            ref Field currentField = ref fields[this.Position];

            if (this.Counter + dieValue > 56)
            {
                //currentField.TokensOnField.Remove(this);
                //currentField.Color = GameColor.White; //Clears the currentField

                //UpdateTokenMovement(0, TokenState.Finished);

                return;
            }

            ref Field fieldToMove = ref fields[this.Position + dieValue]; //Field to move token to

            //currentField.TokensOnField.Remove(this);
            //currentField.Color = GameColor.White; //Clears the currentField


            if (this.Position + dieValue > 51 && this.State != PieceState.Safe)
            {
                this.Position -= 52;

            }

            if (this.State == PieceState.Home)
            {
                UpdateTokenMovement(0); //Sets the token on the board
                //fieldToMove.TokensOnField.Add(this);
                //fieldToMove.Color = this.Color;
            }
            else
            {

                //if (fieldToMove.TokensOnField.Count > 0)
                //{
                //    //Token(s) on field further validate
                //    if (fieldToMove.Color != this.Color && fieldToMove.TokensOnField.Count > 1)
                //    {
                //        ResetToken(this);
                //    }
                //    else if (fieldToMove.Color == this.Color)
                //    {
                //        UpdateTokenMovement(dieValue);
                //        fieldToMove.TokensOnField.Add(this);
                //        fieldToMove.Color = this.Color;

                //    }
                //}
                //TODO Move
                UpdateTokenMovement(dieValue);
                //fieldToMove.TokensOnField.Add(this);
                //fieldToMove.Color = this.Color;
            }
        }

        private void UpdateTokenMovement(int dieValue, PieceState state = PieceState.InPlay)
        {
            this.Position += dieValue;
            this.Counter += dieValue;
            this.State = state;
            Debug.WriteLine(this.Counter);
        }

        private void ResetToken(Piece token)
        {

            token.Position = token.StartPosition;
            token.State = PieceState.Home;
            token.Counter = 0;
        }

        #region Properties

        //Gets the id of the currently selected token
        public int Id { get; private set; }

        /// <summary>
        /// Gets the current color returned in GameColor (ReadOnly)
        /// </summary>
        public GameColor Color { get; private set; }

        /// <summary>
        /// Gets the current state returned in TokenState
        /// </summary>
        public PieceState State { get; private set; }

        /// <summary>
        /// Gets the current position
        /// </summary>
        public int Position { get; private set; }

        /// <summary>
        /// Gets the startposition
        /// </summary>
        public int StartPosition { get; private set; }

        /// <summary>
        /// Count up to 52? then moves token to safe
        /// </summary>
        public int Counter { get; private set; }

        /// <summary>
        /// If true the token can move else false
        /// </summary>
        public bool CanMove { get; set; }

        #endregion

        public override string ToString()
        {
            return "PieceId: " + Id + ", Color: " + Color;
        }
    }
}
