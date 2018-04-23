using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Base
{
    class Game
    {

        #region Fields
        private readonly int numberOfPlayers; //Defines the number of players in the game
        //private readonly int delay = 120; //The General delay for output
        private int playerTurn = 0; //Defines the player's turn
        private int tries = 0;

        private Player[] players; //defines the array of players
        private Field[] fields; //Defines the fields in the game
        private Dice die = new Dice(); //Makes an object of the class 'Dice'

        #endregion

        public Game()
        {
            CreatePlayers(); //This method creates the players
            Turn(); //Begins player one's turn
        }

        #region Initialization

        private void CreatePlayers()
        {
            this.players = new Player[this.numberOfPlayers]; //Initializes the players array
            
            for (int i = 0; i < this.numberOfPlayers; i++) //Runs until all users have names
            {
                //Console.Write("What is the name of player {0}: ", (i + 1)); //Asks for the players name
                //string name = Console.ReadLine(); //saves the name as a temporary variable called 'name'

                Piece[] pieces = TokenAssign(i); //Assigns the tokens for the different users

                //players[i] = new Player(name, (i + 1), pieces); //Initalizes each player in the array

                //PrintLog("Player " + i + " name: " + name);

            }
        }

        //Assigns the tokens -- used in the method above
        private Piece[] TokenAssign(int index)
        {
            Piece[] pieces = new Piece[4]; //Makes a new temporary array

            for (int i = 0; i <= 3; i++) //runs four times
            {
                switch (index) //gives the same color to the tokens as the player
                {
                    case 0:
                        pieces[i] = new Piece((i + 1), GameColor.Yellow, 0); //Defines the color for the token
                        break;
                    case 1:
                        pieces[i] = new Piece((i + 1), GameColor.Blue, 13); //Defines the color for the token
                        break;
                    case 2:
                        pieces[i] = new Piece((i + 1), GameColor.Red, 26); //Defines the color for the token
                        break;
                    case 3:
                        pieces[i] = new Piece((i + 1), GameColor.Green, 39); //Defines the color for the token
                        break;
                }
            }
            return pieces;
        }

        #endregion

        #region MainGameplay

        //Each players turn
        private void Turn()
        {
            while (true) //Checks if the game is on
            {
                Player turn = players[(playerTurn)]; //Finds the player in the array
                //do
                //{
                //    Console.Write("Press 'K' to roll the die: ");
                //}
                //while (Console.ReadKey().KeyChar != 'k');
                //Console.WriteLine("You got: " + die.ThrowDice());
                CanMove(turn); //Checks if the player can move
            }
        }

        //OPTIMIZE CanMove
        //Checks if the player can move
        private void CanMove(Player turn)
        {
            Piece[] pieces = turn.GetPieces();

            int choice = 0; //How many tokens can the player move
            int finish = 0;
            
            foreach (Piece ps in pieces) //Begins to write the tokens of the player
            {
                switch (ps.State) //Begins to check if the player can do anything with his/hers tokens
                {
                    case PieceState.Home:
                        //if (die.GetValue == 6)
                        //{
                            //Console.Write(" - Can move");
                            choice++; //Can move this token AKA a choice
                            ps.CanMove = true;
                        //}
                        //else
                        //{
                            //Console.Write(" - Can not move");
                            ps.CanMove = false;
                        //}
                        break;
                    case PieceState.Finished:
                        //Console.Write(" <- Is finished");
                        ps.CanMove = false;
                        finish++;
                        break;
                    default:
                        //Console.Write(" <- Can move : " + ps.Position + " ");
                        choice++;
                        ps.CanMove = true;
                        break;
                }
            }

            if (finish >= 4)
            {
                Finish(turn); //Finishes the game
            }

            //Console.WriteLine(pieces[0].Color.ToString() + " have " + choice.ToString() + " options in this turn\n");

            tries++;

            //if (tries < 3 && die.GetValue < 6 && choice == 0)
            //{
            //    Turn();
            //}

            tries = 0;

            if (choice == 0) //Cant do anything this turn skips the player
            {
                ChangeTurn();
            }
            else
            {
                MoveToField(players[playerTurn]);
                ChangeTurn();
            }
        }

        //Changes the turn to the next player
        private void ChangeTurn()
        {
            if (playerTurn == (numberOfPlayers - 1))
            {
                playerTurn = 0;
            }
            else
            {
                playerTurn++;
            }
            Turn();
        }

        #endregion

        #region Movement

        //Lets the player choose the token to move
        private int ChooseTokenToMove()
        {
            int tokenToMove = 0; //Temporary variable
            
            while (tokenToMove < 1 || tokenToMove > 4)
            {
                //if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out tokenToMove))
                //{
                //}
            }
            return tokenToMove - 1;
        }

        //Moves the token
        //OPTIMIZE MoveToField
        private void MoveToField(Player player)
        {

            Piece turnPiece = player.GetPiece(ChooseTokenToMove());

            if (!turnPiece.CanMove)
            {
                MoveToField(player);
            }
            else
            {
                //turnPiece.MoveToken(ref fields, die.GetValue);
            }
        }

        #endregion

        private void Finish(Player winner)
        {

            Environment.Exit(0);
        }

        [Conditional("DEBUG")]
        private void PrintLog(string dataLog)
        {
            Debug.WriteLine(dataLog);
        }
    }
}
