using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #endregion

        public void AddPlayer(string name, int id)
        {
            if (!String.IsNullOrWhiteSpace(name))
                this.players.Add(new Player(name, id, CreatePieces(id), AddPlayerFields()));
        }

        private Piece[] CreatePieces(int id)
        {
            Piece[] tmpPieces = new Piece[4];
            switch (id)
            {
                case 1:
                    for (int i = 0; i < 4; i++)
                        tmpPieces[i] = new Piece(id, GameColor.Green, 1);
                    break;
                case 2:
                    for (int i = 0; i < 4; i++)
                        tmpPieces[i] = new Piece(id, GameColor.Yellow, 14);
                    break;
                case 3:
                    for (int i = 0; i < 4; i++)
                        tmpPieces[i] = new Piece(id, GameColor.Blue, 27);
                    break;
                case 4:
                    for (int i = 0; i < 4; i++)
                        tmpPieces[i] = new Piece(id, GameColor.Red, 40);
                    break;
            }
            return tmpPieces;
        }

        public List<Field> GetPlayerFields(int id)
        {
            throw new NotImplementedException();
        }

        public List<Field> AddPlayerFields()
        {
            //List<Field> tmpUserFields = new List<Field>(9);
            //for(int i = 1; i <= 9; i++)
            //{
            //    if (i <= 4)
            //        tmpUserFields[(i - 1)] = new Fields.Home();
            //}

            return null;
        }

        public void DrawBoard(Canvas canvas)
        {
            GenerateFields();

            fields.ForEach((Field field) =>
            {
                canvas.Children.Add(field);
                Canvas.SetLeft(field, field.PosX);
                Canvas.SetTop(field, field.PosY);
            });
        }

        public Field GetField(int id)
        {
            throw new NotImplementedException();
        }

        public Field GetNextField(IGamePiece piece, int offset)
        {
            throw new NotImplementedException();
        }

        public List<Field> GetNextFields(IGamePiece piece, int dieValue)
        {
            throw new NotImplementedException();
        }

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

        public bool IsPiecePlaced(Field field)
        {
            throw new NotImplementedException();
        }

        public void KillPiece(ref Piece piece)
        {
            throw new NotImplementedException();
        }

        public void MovePiece(ref List<Field> fields, int pieceTurn, int dieRoll)
        {
            throw new NotImplementedException();
        }

        public void RemovePiece(ref Field field, ref IGamePiece piece)
        {
            field.RemovePiece(piece);
        }


        // Draws a new image on the field
        public void UpdateField(Field field, ImageBrush image)
        {
            throw new NotImplementedException();
        }

        // EVENT: Used to validate the fields in front of the piece...
        public void Piece_OnMove(IGamePiece piece, int dieValue)
        {
            // TODO Implement eventcode
        }

        // Updates the die when the users rolls it.

        public void UpdateDie(ImageBrush image)
        {
            throw new NotImplementedException();
        }

        private void GenerateFields()
        {
            for(int i = 1; i <= 51; i++)
            {
                if (i == 1)
                    fields.Add(new Fields.White(i, 32 * i, 250));
                else if (i == 2)
                    fields.Add(new Fields.Start(i, 32 * i, 250));
                else if (i <= 6)
                    fields.Add(new Fields.White(i, 32 * i, 250));
                // GO UP!
                else if (i <= 12)
                    fields.Add(new Fields.White(i, 226, 250 - 32 * (i - 6)));
                // GO RIGHT!
                else if (i <= 14)
                    fields.Add(new Fields.White(i, 226 + 32 * (i - 12), 58));
                // GO DOWN!
                else if (i <= 19)
                    fields.Add(new Fields.White(i, 290, 58 + 32 * (i - 14)));
                // GO RIGHT!
                else if (i <= 25)
                    fields.Add(new Fields.White(i, 290 + 32 * (i - 19), 250));
                // GO DOWN!
                else if (i <= 27)
                    fields.Add(new Fields.White(i, 482, 250 + 32 * (i - 25)));
                // GO LEFT!
                else if (i <= 32)
                    fields.Add(new Fields.White(i, 482 - 32 * (i - 27), 314));
                // GO DOWN!
                else if (i <= 38)
                    fields.Add(new Fields.White(i, 290, 314 + 32 * (i - 32)));
            }
        }

        

        public List<Player> GetPlayers => this.players;

        public List<Field> GetFields => this.fields;
    }
}
