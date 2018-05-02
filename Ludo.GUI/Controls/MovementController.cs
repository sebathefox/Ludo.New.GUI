﻿using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.GUI.Controls
{
    class MovementController : Ludo.Base.IGameMovement
    {

        /// <summary>
        /// Moves the piece and cleans it's path
        /// </summary>
        /// <param name="field">The field that was clicked</param>
        /// <param name="fields">the list of fields to use as board</param>
        /// <param name="player">the turn player</param>
        /// <param name="dieValue">the value of the die</param>
        public void Move( ref Field field, ref List<Field> fields, ref Player player, int dieValue)
        {
            // Checks if there is any pieces to move
            if (field.GetPieces.Count != 0)
            {
                // The piece to move (Always chooses the first in the stack)
                Piece piece = (Piece)field.GetPieces.First();

                if (piece.GetPosition() + dieValue > 51 && piece.State != PieceState.Safe)
                {
                    piece.SetPosition((piece.GetPosition() - 52));
                }

                // The field to move to
                Field fieldToMove = fields[(piece.GetPosition() + dieValue)];

                // TODO change from exception
                if (!piece.CanMove && player.Color == piece.Color)
                    throw new Exception("ERROR: Piece cannot move.");

                else if (piece.Counter + dieValue >= 55)
                {
                    piece.State = PieceState.Finished;
                    field.Color = GameColor.White;
                    UpdateField(field, field.GetDefaultImage());
                }

                else if (piece.Counter + dieValue >= 50)
                {
                    int tmpMath = piece.GetPosition() + dieValue - piece.GetSafePosition;
                    fieldToMove = fields[(piece.GetSafePosition + tmpMath)];
                    PlacePiece(piece, fieldToMove, PieceState.Safe, dieValue);
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
                    if (fieldToMove.GetPieces[0].Color != piece.Color)
                        KillPiece(ref piece);
                    else
                    {
                        PlacePiece(piece, fieldToMove, PieceState.InPlay, dieValue);
                        ResetField(field);
                    }
                }
                else
                {
                    PlacePiece(piece, fieldToMove, PieceState.InPlay, dieValue);
                    ResetField(field);
                }
            }
            else Debug.WriteLine("Player tried to move a token from an empty field");
        }

        /// <summary>
        /// Updates the image of a field
        /// </summary>
        /// <param name="field">The field to update</param>
        /// <param name="image">The image to set as background</param>
        public void UpdateField(Field field, ImageBrush image)
        {
            field.Background = image;
        }



        /// <summary>
        /// Places the selected piece on the selected field
        /// </summary>
        /// <param name="piece">Piece to place</param>
        /// <param name="field">Field to place piece on</param>
        /// <param name="state">State of the piece</param>
        public void PlacePiece(Piece piece, Field field, PieceState state, int dieValue)
        {
            //First configure the piece
            piece.SetPosition(piece.GetPosition() + dieValue);
            piece.Counter += dieValue;
            piece.State = state;

            //Then configure the field
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
            field.SetDefaultImage(); // First resets the background image
            for (int i = 0; i < field.GetPieces.Count; i++)
            {
                field.RemovePiece(field.GetPieces[i]); // Removes every piece from the field
            }

            if (field is Fields.White)
            {
                Fields.White fie = field as Fields.White;
                fie.SetColor = GameColor.White;
            }
            else if (field is Fields.Star)
            {
                Fields.Star fie = field as Fields.Star;
                fie.SetColor = GameColor.White;
            }
            else if (field is Fields.Globe)
            {
                Fields.Globe fie = field as Fields.Globe;
                fie.Color = GameColor.White;
            }
        }

        /// <summary>
        /// Checks if there is any pieces at the specified field
        /// </summary>
        /// <param name="field">the field to search</param>
        /// <returns>True if any pieces otherwise false</returns>
        public bool IsPiecePlaced(Field field)
        {
            return field.GetPieces.Count != 0 ? true : false;
        }

        /// <summary>
        /// "Kills" the specified piece and resets its metadata
        /// </summary>
        /// <param name="piece">The piece to "kill"</param>
        public void KillPiece(ref Piece piece)
        {
            piece.Counter = 0;
            piece.State = PieceState.Home;
            piece.SetPosition(piece.StartPosition);
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
    }
}
