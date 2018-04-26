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
        private GameManager manager = new GameManager();

        public MainWindow()
        {
            InitializeComponent();
        }


        // Sets the playernames so that the players can be instanciated
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerInput.Visibility = System.Windows.Visibility.Collapsed;
            
            List<string> vs = new List<string>(4)
            {
                Player1Input.Text,
                Player2Input.Text,
                Player3Input.Text,
                Player4Input.Text
            };

            for (int i = 0; i < vs.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(vs[i]))
                {
                    vs.Remove(vs[i]);
                }
                else
                {
                    Players.Items.Add(vs[i]);
                    manager.AddPlayer(vs[i], i + 1);
                }
            }
            
            // Debug output
            foreach (string pn in vs)
            {
                Debug.WriteLine("Name: " + pn);
                
            }
            this.RollDie.Background = (ImageBrush)FindResource("WhiteField");
            this.RollDie.Visibility = Visibility.Visible;

            manager.DrawBoard(GameBoard);
            
        }

        // Exit button has been clicked
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerInput.Visibility = System.Windows.Visibility.Collapsed;

            Environment.Exit(0); // Exits the program with no errors
        }

        private void Piece_OnMove(IGamePiece piece, int oldField, int newField)
        {
            // TODO Move event to GameManager
        }

        private void Die_Click(object sender, RoutedEventArgs e)
        {
            manager.UpdateDie(this.RollDie);
            manager.Turn();
            manager.ChangeTurn();
        }
    }
}
