using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Ludo.GUI.Fields;

namespace Ludo.GUI.Controls
{
    class MovementController : IGameMovement
    {
        private Field homeField;
        
        public MovementController(Finished eDelegate)
        {
            this.OnMove += eDelegate;
        }

        /// <summary>
        /// Moves the piece and cleans it's path
        /// </summary>
        /// <param name="field">The field that was clicked</param>
        /// <param name="fields">the list of fields to use as board</param>
        /// <param name="player">the turn player</param>
        /// <param name="dieValue">the value of the die</param>
        public void Move( ref Field field, ref List<Field> fields, ref Player player, int dieValue)
        {
            Fields = fields;
            
            // Checks if there is any pieces to move
            if (field.GetPieces.Count != 0)
            {
                // The piece to move (Always chooses the first in the stack)
                Piece piece = (Piece)field.GetPieces.First();

                homeField = player.GetPlayerFields[(piece.BasePosition)];

                if (piece.GetPosition() + dieValue > 51 && piece.State != PieceState.Safe)
                {
                    piece.SetPosition((piece.GetPosition() - 52));
                }

                // The field to move to
                Field fieldToMove = fields[(piece.GetPosition() + dieValue)];

                // TODO change from exception
                if (!piece.CanMove && player.Color != piece.Color)
                    throw new Exception("ERROR: Piece cannot move.");

                else if (piece.Counter + dieValue > 55)
                {
                    
                    //field.Color = GameColor.White;
                    UpdateField(field, field.GetDefaultImage());
                    ResetField(field);
                    piece.State = PieceState.Finished;
                    OnMove?.Invoke(this, piece); // Fires the event only if there is any listeners
                }

                else if (piece.Counter + dieValue >= 50)
                {
                    int tmpMath = piece.GetPosition() + dieValue - piece.GetSafePosition;
                    fieldToMove = fields[(piece.GetSafePosition + tmpMath)];
                    PlacePiece(piece, fieldToMove, PieceState.Safe, dieValue);
                    ResetField(field);
                }

                else if (piece.State == PieceState.Home)
                {
                    fieldToMove = fields[(piece.StartPosition)];

                    piece.State = PieceState.InPlay;
                    fieldToMove.AddPiece(piece);
                    UpdateField(fieldToMove, GetImage(piece.Color, fieldToMove));
                    ResetField(field);
                }

                else if (IsPiecePlaced(fieldToMove))
                {
                    if (fieldToMove.GetPieces.Count > 1 && fieldToMove.Color != piece.Color)
                    {
                        KillPiece(ref piece);
                        return;
                    }
                }
                else if (IsSpecialField(fieldToMove) != FieldType.BaseField)
                {
                    MovementController dis = this;

                    switch (fieldToMove)
                    {
                        case Globe glo:
                            glo.Protec(ref piece, ref field, ref glo, ref dis, dieValue);
                            break;
                        case Start sta:
                            sta.Protec(ref piece, ref field, ref sta, ref dis, dieValue);
                            break;
                        case Star star:
                            star.Protec(ref piece, ref field, ref dis);
                            break;
                    }
                }
                else
                {
                    PlacePiece(piece, fieldToMove, PieceState.InPlay, dieValue);
                    ResetField(field);
                }
            }
            else Trace.WriteLine("\nPlayer tried to move a token from an empty field");

            foreach (Piece piece in player.GetPieces())
            {
                piece.CanMove = false;
            }
        }

        /// <summary>
        /// Updates the image of a field
        /// </summary>
        /// <param name="field">The field to update</param>
        /// <param name="image">The image to set as background</param>
        public void UpdateField(Field field, ImageBrush image)
        {
            LogControl.Log("");
            LogControl.Log("POST: " + field);
            if (field.GetPieces.Count <= 1)
                field.Background = image;
        }


        /// <summary>
        /// Places the selected piece on the selected field
        /// </summary>
        /// <param name="piece">Piece to place</param>
        /// <param name="field">Field to place piece on</param>
        /// <param name="state">State of the piece</param>
        /// <param name="dieValue">The value of the die</param>
        public void PlacePiece(Piece piece, Field field, PieceState state, int dieValue)
        {
            // Configure the piece
            if (state != PieceState.Safe || state != PieceState.Home)
                piece.SetPosition(piece.GetPosition() + dieValue);
            else
                piece.SetPosition(field.Id);
            piece.Counter += dieValue;
            piece.State = state;
            piece.CanMove = false;

            // Then configure the field
            field.Color = piece.Color;
            field.AddPiece(piece);
            UpdateField(field, GetImage(piece.Color, field));
        }

        /// <summary>
        /// Resets the specified field back to it's default values
        /// </summary>
        /// <param name="field">The field to reset</param>
        public void ResetField(Field field)
        {
            LogControl.Log("");
            LogControl.Log("PRE: " + field);

            field.RemovePiece(field.GetPieces.First()); // Removes every piece from the field
            if (field.GetPieces.Count < 1)
                field.SetDefaultImage(); // First resets the background image

            switch (field)
            {
                case White fie1:
                    fie1.SetColor = GameColor.White;
                    break;
                case Star fie2:
                    fie2.SetColor = GameColor.White;
                    break;
                case Globe fie3:
                    fie3.Color = GameColor.White;
                    break;
            }
        }
        
        /// <summary>
        /// Checks if there is any pieces at the specified field
        /// </summary>
        /// <param name="field">the field to search</param>
        /// <returns>True if any pieces otherwise false</returns>
        public bool IsPiecePlaced(Field field) => field.GetPieces.Count != 0;

        /// <summary>
        /// Checks if the field is a special field
        /// </summary>
        /// <param name="field">The field to validate</param>
        /// <returns>The type of field</returns>
        public FieldType IsSpecialField(Field field)
        {
            switch (field.Type)
            {
                case FieldType.GlobeField:
                    return FieldType.GlobeField;
                case FieldType.StarField:
                    return FieldType.StarField;
                case FieldType.StartField:
                    return FieldType.StartField;
                //case FieldType.HomeField:
                //    return FieldType.HomeField;
                //case FieldType.SafeField:
                //    return FieldType.SafeField;
                default:
                    return FieldType.BaseField;
            }
        }

        /// <summary>
        /// "Kills" the specified piece and resets its metadata
        /// </summary>
        /// <param name="piece">The piece to "kill"</param>
        public void KillPiece(ref Piece piece)
        {
            piece.CanMove = false;
            piece.Counter = 0;
            piece.State = PieceState.Home;
            piece.SetPosition(piece.StartPosition);
            PlacePiece(piece, homeField, PieceState.Home, 0);
        }

        /// <summary>
        /// Gets the image of a specific piece
        /// </summary>
        /// <param name="color">The color of the piece</param>
        /// <param name="field">The piece to update</param>
        /// <returns>Returns the image</returns>
        private ImageBrush GetImage(GameColor color, Field field)
        {
            switch (color)
            {
                case GameColor.Green:
                    return (ImageBrush)field.FindResource("GreenPiece");
                case GameColor.Yellow:
                    return (ImageBrush)field.FindResource("YellowPiece");
                case GameColor.Blue:
                    return (ImageBrush)field.FindResource("BluePiece");
                case GameColor.Red:
                    return (ImageBrush)field.FindResource("RedPiece");
                default:
                    throw new Exception("Unknown Error.");
            }
        }

        public event Finished OnMove;

        public List<Field> Fields { get; private set; }
    }
}
