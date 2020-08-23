using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void StartTwoPlayersGame(object sender, RoutedEventArgs e)
        {
            var twoPlayersGame = new MainWindow();
            this.Visibility = Visibility.Hidden;
            twoPlayersGame.Show();
        }

        private void StartOnlineGame(object sender, RoutedEventArgs e)
        {
            var startOnlineGame = new StartOnline();
            this.Visibility = Visibility.Hidden;
            startOnlineGame.Show();
        }
    }
}
