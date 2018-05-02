using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ludo.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager manager = new GameManager();
        List<string> playerNames;
        private int index = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Sets the playernames so the players can be instanciated
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            // Hides the playername selector
            PlayerInput.Visibility = System.Windows.Visibility.Collapsed;
            
            // List of playernames
            playerNames = new List<string>(4)
            {
                Player1Input.Text,
                Player2Input.Text,
                Player3Input.Text,
                Player4Input.Text
            };

            for (int i = 0; i < playerNames.Count; i++)
            {
                // Validates if it's a valid player
                if (String.IsNullOrWhiteSpace(playerNames[i]))
                {
                    playerNames.Remove(playerNames[i]);
                }
                else
                {
                    Players.Items.Add(playerNames[i]);
                    manager.AddPlayer(playerNames[i], i + 1);
                }
            }
            
            // Debug output
            foreach (string pn in playerNames)
            {
                Debug.WriteLine("Name: " + pn);
                
            }
            this.RollDie.Background = (ImageBrush)FindResource("WhiteField");
            this.RollDie.Visibility = Visibility.Visible;

            // Draws the board
            manager.DrawBoard(GameBoard);
        }

        // Exit button has been clicked
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0); // Exits the program with no errors
        }

        private void Die_Click(object sender, RoutedEventArgs e)
        {
            manager.UpdateDie(this.RollDie); // Updates the die's graphics
            manager.Turn(); // The current player's turn
            manager.ChangeTurn();// Changes the turn to the next player

            
            
            // Shows the current players turn
            PlayerTurn.Text = "Player " + manager.GetPlayer(index).Name + "'s turn";

            // Used for the PlayerTurn field
            index++;
            if (index >= manager.GetPlayers().Count)
                index = 0;
        }
    }
}
