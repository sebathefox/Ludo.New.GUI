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
        private List<Field> fields = new List<Field>();

        public MainWindow()
        {
            InitializeComponent();
        }


        // Sets the playernames so that the players can be instanciated
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerInput.Visibility = System.Windows.Visibility.Collapsed;

            // Temporary list to hold the the playernames until they have been saved in their Player objects
            List<string> playerNames = new List<string>(4)
            {
                Player1Input.Text,
                Player2Input.Text,
                Player3Input.Text,
                Player4Input.Text
            };

            playerNames.ForEach((string data) =>
            {
                if (String.IsNullOrWhiteSpace(data))
                {
                    data = null;
                }
                else
                    Players.Items.Add(data);
            });


            // Debug output
            foreach (string pn in playerNames)
            {
                Debug.WriteLine("Name: " + pn);
                
            }

            DrawBoard();
        }

        // Exit button has been clicked
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerInput.Visibility = System.Windows.Visibility.Collapsed;

            Environment.Exit(0); // Exits the program with no errors
        }

        private void Piece_OnMove(IGamePiece piece, int oldField, int newField)
        {

        }

        private void DrawBoard()
        {

            for (int i = 1; i <= 52; i++)
            {
                if (i == 1)
                    fields.Add(new Fields.White(i));
                else if (i == 2)
                    fields.Add(new Fields.Start(i));
                else if (i <= 6)
                    fields.Add(new Fields.White(i));
                // GO UP!!
                else if (i <= 12)
                    fields.Add(new Fields.White(i));
            }


            // Adds the fields to the board
            fields.ForEach((Field field) =>
            {
                GameBoard.Children.Add(field);
            });
        }
    }
}
