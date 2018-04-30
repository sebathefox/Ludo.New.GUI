using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ludo.Base;

namespace Ludo.GUI
{
    public class GameManager : IGameController
    {
        #region Fields

        private List<Player> players = new List<Player>(4);
        private List<Field> fields = new List<Field>();
        private Dice dice = new Dice();
        private Field[] startFields;

        private int playerTurn = 0;
        #endregion

        /// <summary>
        /// Adds a new player to the controller
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="id">The id of the player</param>
        public void AddPlayer(string name, int id)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                Piece[] pieces = CreatePieces(id);

                this.players.Add(new Player(name, id, pieces, AddPlayerFields(pieces[0].Color, id)));
            }
        }

        /// <summary>
        /// Creates the individual player pieces
        /// </summary>
        /// <param name="id">The id of the player</param>
        /// <returns>A list of the playerspecific pieces</returns>
        private Piece[] CreatePieces(int id)
        {
            Piece[] tmpPieces = new Piece[4];
            for(int i = 0; i < 4; i++)
            {
                switch (id)
                {
                    case 1:
                        tmpPieces[i] = new Piece(i + 1, GameColor.Green, 1);
                        break;
                    case 2:
                        tmpPieces[i] = new Piece(i + 1, GameColor.Yellow, 14);
                        break;
                    case 3:
                        tmpPieces[i] = new Piece(i + 1, GameColor.Blue, 27);
                        break;
                    case 4:
                        tmpPieces[i] = new Piece(i + 1, GameColor.Red, 40);
                        break;
                }
            }
            return tmpPieces;
        }

        /// <summary>
        /// Adds the player's homefields
        /// </summary>
        /// <param name="color">The color of the fields</param>
        /// <param name="offset">The offset of the playerfields</param>
        /// <returns></returns>
        public List<Field> AddPlayerFields(GameColor color, int offset)
        {
            int x = 0;
            int y = 0;
            switch (offset)
            {
                case 1:
                    x = 64;
                    y = 96;
                    break;
                case 2:
                    x = 350;
                    y = 96;
                    break;
                case 3:
                    x = 350;
                    y = 400;
                    break;
                case 4:
                    x = 64;
                    y = 400;
                    break;
            }
            List<Field> tmpUserFields = new List<Field>(9);
            for (int i = 1; i <= 9; i++)
            {
                if (i <= 4)
                    if (i < 3)
                        tmpUserFields.Add(new Fields.Home(i, x + 48 * i, y, color));
                    else
                        tmpUserFields.Add(new Fields.Home(i, x + 48 * (i - 2), y + 64, color));
            }
            return tmpUserFields;
        }

        /// <summary>
        /// Draws the board on the screen
        /// </summary>
        /// <param name="canvas">The canvas object to draw the board on</param>
        public void DrawBoard(Canvas canvas)
        {
            GenerateFields();

            fields.ForEach((Field field) =>
            {
                field.Style = (System.Windows.Style)field.FindResource("btn");
                field.Click += this.FieldClick;

                canvas.Children.Add(field);
                Canvas.SetLeft(field, field.PosX);
                Canvas.SetTop(field, field.PosY);
            });

            players.ForEach((Player player) =>
            {
                List<Field> fields = player.GetPlayerFields;
                fields.ForEach((Field field) =>
                {
                    field.Style = (System.Windows.Style)field.FindResource("btn");
                    field.Click += this.FieldClick;

                    canvas.Children.Add(field);
                    Canvas.SetLeft(field, field.PosX);
                    Canvas.SetTop(field, field.PosY);
                });
            });
        }

        /// <summary>
        /// Gets the id of the player at the specified index
        /// </summary>
        /// <param name="id">the specified index</param>
        /// <returns>The player object at the index</returns>
        public Player GetPlayer(int id)
        {
            try
            {
                return this.players[id];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException(e.Data.ToString());
            } 
        }


        /// <summary>
        /// Validates if the player can move any piece and handles accordingly
        /// </summary>
        public void Turn()
        {
            Player turn = players[playerTurn];

            Piece[] pieces = turn.GetPieces();
            int choice = 0;

            foreach (Piece pcs in pieces)
            {
                switch (pcs.State)
                {
                    case PieceState.Home:
                        if (dice.Value == 6)
                        {
                            pcs.CanMove = true;
                            choice++;
                        }
                        else
                            pcs.CanMove = false;
                        break;
                    case PieceState.Finished:
                        pcs.CanMove = false;
                        choice++;
                        break;
                    default:
                        pcs.CanMove = true;
                        choice++;
                        break;
                }
                Debug.WriteLine("DEBUG: PieceState: " + pcs.State);
            }
            if (choice == 0)
                Debug.WriteLine("Player " + turn.Name + " Could not move any pieces this turn");
        }

        /// <summary>
        /// Changes the turn
        /// </summary>
        public void ChangeTurn()
        {
            if (playerTurn == (players.Count - 1))
            {
                playerTurn = 0;
            }
            else
            {
                playerTurn++;
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
        /// Resets the specified field back to it's default values
        /// </summary>
        /// <param name="field">The field to reset</param>
        private void ResetField(Field field)
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
                fie.SetColor = GameColor.White;
            }
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
        /// Updates the dice's graphics
        /// </summary>
        /// <param name="button">The button object that is acting as the die</param>
        public void UpdateDie(Button button)
        {
            this.dice.Throw();
            switch(this.dice.Value)
            {
                case 1:
                    button.Background = (ImageBrush)button.FindResource("DieOne");
                    break;
                case 2:
                    button.Background = (ImageBrush)button.FindResource("DieTwo");
                    break;
                case 3:
                    button.Background = (ImageBrush)button.FindResource("DieThree");
                    break;
                case 4:
                    button.Background = (ImageBrush)button.FindResource("DieFour");
                    break;
                case 5:
                    button.Background = (ImageBrush)button.FindResource("DieFive");
                    break;
                case 6:
                    button.Background = (ImageBrush)button.FindResource("DieSix");
                    break;
            }
        }

        // TEMPORARY Needs to be remade
        private void GenerateFields()
        {
            for(int i = 1; i <= 72; i++)
            {
                if (i == 1)
                    fields.Add(new Fields.White(i, 2 + 32 * i, 250));
                else if (i == 2)
                    fields.Add(new Fields.Start(i, 2 + 32 * i, 250, GameColor.Green));
                else if (i <= 6)
                    fields.Add(new Fields.White(i, 2 + 32 * i, 250));
                // GO UP!
                else if (i <= 12)
                    if (i == 7)
                        fields.Add(new Fields.Star(i, 226, 250 - 32 * (i - 6)));
                    else if (i == 10)
                        fields.Add(new Fields.Globe(i, 226, 250 - 32 * (i - 6)));
                    else
                        fields.Add(new Fields.White(i, 226, 250 - 32 * (i - 6)));
                // GO RIGHT!
                else if (i <= 14)
                    if (i == 13)
                        fields.Add(new Fields.Star(i, 226 + 32 * (i - 12), 58));
                    else
                        fields.Add(new Fields.White(i, 226 + 32 * (i - 12), 58));
                // GO DOWN!
                else if (i <= 19)
                    if (i == 15)
                        fields.Add(new Fields.Start(i, 290, 58 + 32 * (i - 14), GameColor.Yellow));
                    else
                        fields.Add(new Fields.White(i, 290, 58 + 32 * (i - 14)));
                // GO RIGHT!
                else if (i <= 25)
                    if (i == 20)
                        fields.Add(new Fields.Star(i, 290 + 32 * (i - 19), 250));
                    else if (i == 23)
                        fields.Add(new Fields.Globe(i, 290 + 32 * (i - 19), 250));
                    else
                        fields.Add(new Fields.White(i, 290 + 32 * (i - 19), 250));
                // GO DOWN!
                else if (i <= 27)
                    if (i == 26)
                        fields.Add(new Fields.Star(i, 482, 250 + 32 * (i - 25)));
                    else
                        fields.Add(new Fields.White(i, 482, 250 + 32 * (i - 25)));
                // GO LEFT!
                else if (i <= 32)
                    if (i == 28)
                        fields.Add(new Fields.Start(i, 482 - 32 * (i - 27), 314, GameColor.Blue));
                    else
                        fields.Add(new Fields.White(i, 482 - 32 * (i - 27), 314));
                // GO DOWN!
                else if (i <= 38)
                    if (i == 33)
                        fields.Add(new Fields.Star(i, 290, 314 + 32 * (i - 32)));
                    else if (i == 36)
                        fields.Add(new Fields.Globe(i, 290, 314 + 32 * (i - 32)));
                    else
                        fields.Add(new Fields.White(i, 290, 314 + 32 * (i - 32)));
                // GO LEFT!
                else if (i <= 40)
                    if (i == 39)
                        fields.Add(new Fields.Star(i, 290 - 32 * (i - 38), 506));
                    else
                        fields.Add(new Fields.White(i, 290 - 32 * (i - 38), 506));
                // GO UP!
                else if (i <= 45)
                    if (i == 41)
                        fields.Add(new Fields.Start(i, 226, 506 - 32 * (i - 40), GameColor.Red));
                    else
                        fields.Add(new Fields.White(i, 226, 506 - 32 * (i - 40)));
                // GO LEFT!
                else if (i <= 51)
                    if (i == 46)
                        fields.Add(new Fields.Star(i, 226 - 32 * (i - 45), 314));
                    else if (i == 49)
                        fields.Add(new Fields.Globe(i, 226 - 32 * (i - 45), 314));
                    else
                        fields.Add(new Fields.White(i, 226 - 32 * (i - 45), 314));
                // GO UP!
                else if (i == 52)
                    fields.Add(new Fields.Star(i, 34, 282));

                // Add green safe fields
                else if (i <= 57)
                    fields.Add(new Fields.Safe(i, 34 + 32 * (i - 52), 282, GameColor.Green));

                // Add yellow safe fields
                else if (i <= 62)
                    fields.Add(new Fields.Safe(i, 258, 58 + 32 * (i - 57), GameColor.Yellow));

                // Add red safe fields
                else if (i <= 67)
                    fields.Add(new Fields.Safe(i, 290 + 32 * (i - 62), 282, GameColor.Blue));

                // Add blue safe fields
                else if (i <= 72)
                    fields.Add(new Fields.Safe(i, 258, 506 - 32 *(i - 67), GameColor.Red));
            }
            // Gets the startfields and adds them to a variable
            startFields = fields.Where(field => field.Type == FieldType.StartField).ToArray();
        }

        // Click event for every field in the game
        private void FieldClick(object sender, RoutedEventArgs e)
        {
            // Converts the object using cast
            Field field = (Field)sender;

            // Checks if there is any pieces to move
            if (field.GetPieces.Count != 0)
            {
                // The piece to move (Always chooses the first in the stack)
                Piece piece = (Piece)field.GetPieces.First();

                if (piece.GetPosition() + dice.Value > 51 && piece.State != PieceState.Safe)
                {
                    piece.SetPosition((piece.GetPosition() - 52));
                }

                // The field to move to
                Field fieldToMove = fields[(piece.GetPosition() + dice.Value)];
                
                // TODO change from exception
                if (!piece.CanMove && players[playerTurn].Color == piece.Color)
                    throw new Exception("ERROR: Piece cannot move.");

                else if (piece.Counter + dice.Value >= 55)
                {
                    piece.State = PieceState.Finished;
                    field.Color = GameColor.White;
                    UpdateField(field, field.GetDefaultImage());
                }

                else if(piece.Counter + dice.Value >= 50)
                {
                    int tmpMath = piece.GetPosition() + dice.Value - piece.GetSafePosition;
                    fieldToMove = fields[(piece.GetSafePosition + tmpMath)];
                    PlacePiece(piece, fieldToMove, PieceState.Safe);
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
                        PlacePiece(piece, fieldToMove, PieceState.InPlay);
                        ResetField(field);
                    }
                }
                else
                {
                    PlacePiece(piece, fieldToMove, PieceState.InPlay);
                    ResetField(field);
                }
                //Debug.WriteLine("Player moved piece: " + fieldToMove.GetPieces.First().ToString());
            }
            else Debug.WriteLine("Player tried to move a token from an empty field");
        }

        /// <summary>
        /// Places the selected piece on the selected field
        /// </summary>
        /// <param name="piece">Piece to place</param>
        /// <param name="field">Field to place piece on</param>
        /// <param name="state">State of the piece</param>
        private void PlacePiece(Piece piece, Field field, PieceState state)
        {
            //First configure the piece
            piece.SetPosition(piece.GetPosition() + dice.Value);
            piece.Counter += dice.Value;
            piece.State = state;

            //Then configure the field
            field.Color = piece.Color;
            field.AddPiece(piece);
            UpdateField(field, GetImage(piece.Color, field));
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
