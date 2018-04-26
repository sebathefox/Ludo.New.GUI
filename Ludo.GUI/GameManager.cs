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
        private int tries = 0;

        #endregion

        /// <summary>
        /// Adds a new player
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
                tmpPieces[i].OnMove += this.Piece_OnMove;
            }
            return tmpPieces;
        }

        public List<Field> GetPlayerFields(int id)
        {
            throw new NotImplementedException();
        }

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
                    x = 64;
                    y = 400;
                    break;
                case 4:
                    x = 350;
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
        /// Draws the board
        /// </summary>
        /// <param name="canvas">the parent object to hold all of the game objects</param>
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
        /// Gets a single field
        /// </summary>
        /// <param name="id">The zero-based index of the field</param>
        /// <returns>Returns the field</returns>
        public Field GetField(int id)
        {
            return this.fields[id];
        }

        /// <summary>
        /// Gets the field after the pieces current position
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public Field GetNextField(IGamePiece piece)
        {
            return this.fields[(piece.GetPosition() + 1)];
        }


        // WHAT?!??!??
        public List<Field> GetNextFields(IGamePiece piece, int dieValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the player of choice
        /// </summary>
        /// <param name="id">The id of the player</param>
        /// <returns>The player</returns>
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

        public void Turn()
        {
            Player turn = players[playerTurn];
            CanMove(turn);
        }


        /// <summary>
        /// Validates if the player can move any piece
        /// </summary>
        /// <param name="turn">The player of this turn</param>
        private void CanMove(Player turn)
        {
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

            tries = 0;

            if (choice != 0)
            {
                // Move
            }
            else
            {
                Debug.WriteLine("Player " + turn.Name + " Could not move any pieces this turn");
            }
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
        /// Checks if any there is any pieces on the field
        /// </summary>
        /// <param name="field">The field to search</param>
        /// <returns>True if pieces else false</returns>
        public bool IsPiecePlaced(Field field)
        {
            return field.GetPieces.Count != 0 ? true : false;
        }

        /// <summary>
        /// Resets the piece to its default values
        /// </summary>
        /// <param name="piece">The piece to reset</param>
        public void KillPiece(ref Piece piece)
        {
            piece.Counter = 0;
            piece.State = PieceState.Home;
            piece.SetPosition(piece.StartPosition);
        }

        public void MovePiece(ref List<Field> fields, int pieceTurn, int dieRoll)
        {
            Piece piece = players[playerTurn].GetPiece(pieceTurn);
            Field currentField = fields[piece.GetPosition()];
            Field fieldToMove = fields[(piece.GetPosition() + dieRoll)];

            // TODO change from exception
            if (!piece.CanMove) throw new Exception("ERROR: Piece cannot move.");
            else if (IsPiecePlaced(fieldToMove))
            {
                if (fieldToMove.GetPieces[0].Color != piece.Color)
                    KillPiece(ref piece);
            }
            else
            {
                // Do this after the piece has been validated!
                piece.SetPosition(piece.GetPosition() + dieRoll);
                
            }
        }

        private void ResetField(Field field)
        {
            field.SetDefaultImage();

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


        // TODO PROBABLY USELESS
        /// <summary>
        /// Removes a piece on a field
        /// </summary>
        /// <param name="field">The field to remove the piece from</param>
        /// <param name="piece">The piece to remove</param>
        public void RemovePiece(ref Field field, ref IGamePiece piece)
        {
            field.RemovePiece(piece);

            if (field.GetPieces.Count == 0)
                ResetField(field);
            else
                UpdateField(field, field.GetDefaultImage());
        }


        /// <summary>
        /// Updates the image of the field you chooses
        /// </summary>
        /// <param name="field">the field to update</param>
        /// <param name="image">The image to use instead</param>
        public void UpdateField(Field field, ImageBrush image)
        {
            field.Background = image;
        }

        // EVENT: Used to validate the fields in front of the piece...
        public void Piece_OnMove(IGamePiece piece)
        {
            // TODO Implement eventcode
        }

        /// <summary>
        /// Updates the die when the click event activates
        /// </summary>
        /// <param name="button">the die button to update</param>
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


        // TODO implement to the GenerateFields method?
        private void GenerateFieldPosition(int index, string posX, string posY)
        {
            DataTable dt = new DataTable();
            int x = (int)dt.Compute(posX, "");
            int y = (int)dt.Compute(posY, "");
        }

        // TEMPORARY Needs to be remade
        private void GenerateFields()
        {

            for(int i = 1; i <= 52; i++)
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
                else
                    fields.Add(new Fields.Star(i, 34, 282));
            }
            startFields = fields.Where(field => field.Type == FieldType.StartField).ToArray();
        }

        private void FieldClick(object sender, RoutedEventArgs e)
        {
            Field field = (Field)sender;

            if (field.GetPieces.Count != 0)
            {
                Debug.WriteLine("Player moved piece: " + field.GetPieces[0].Id);
            }
            else Debug.WriteLine("Player tried to move a token from an empty field");
        }

        public List<Player> GetPlayers => this.players;

        public List<Field> GetFields => this.fields;
    }
}
