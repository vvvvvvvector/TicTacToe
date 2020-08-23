using System;
using System.Collections.Generic;
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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool player = true;
        string[,] board = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            board = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };

            foreach (UIElement ele in PlayBoard.Children)
            {
                if (ele is Button)
                {
                    (ele as Button).Content = null;
                    (ele as Button).IsEnabled = true;
                }
            }
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var currentButton = sender as Button;

            if (currentButton.Content == null)
            {
                var move = GetMove();
                TurnBox.Text = move == "X" ? $"Next move O" : $"Next move X";
                currentButton.Content = move;
                currentButton.IsEnabled = false;
                board[Grid.GetRow(currentButton), Grid.GetColumn(currentButton)] = move;
            }
            CheckWin();
        }
        private string GetMove()
        {
            var ret = "";

            if (player)
                ret = "X";
            else
                ret = "O";

            player = !player;

            return ret;
        }
        private void CheckWin()
        {
            //Vertical Check
            for (int i = 0; i < 3; i++)
            {
                if ((board[0, i] != "" && board[1, i] != "" && board[2, i] != "") && (board[0, i] == board[1, i] && board[0, i] == board[2, i] && board[1, i] == board[2, i]))
                {
                    DisplayMessage();
                }
            }
            //Horizontal Check
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] != "" && board[i, 1] != "" && board[i, 2] != "") && (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 1] == board[i, 2]))
                {
                    DisplayMessage();
                }
            }
            //Diagonal 1 Check
            if ((board[0, 0] != "" && board[1, 1] != "" && board[2, 2] != "") && (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[1, 1] == board[2, 2]))
            {
                DisplayMessage();
            }
            //Diagonal 2 Check
            else if ((board[0, 2] != "" && board[1, 1] != "" && board[2, 0] != "") && (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[1, 1] == board[2, 0]))
            {
                DisplayMessage();
            }
            //looks ugly
            else
            {
                var c = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] != "") c++;
                        else return;
                    }
                }
                if (c == 9) DisplayTieMessage();
            }
        }
        private void DisplayMessage()
        {
            if (MessageBox.Show((player ? "O" : "X") + " wins!\n\nPlay again?", "You win!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Reset();
            else
                Application.Current.Shutdown();
            //Close();
        }
        private void DisplayTieMessage()
        {
            if (MessageBox.Show("Tie board!\n\nPlay again?", "Aww..", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Reset();
            else
                Application.Current.Shutdown();
            //Close();
        }
    }
}
