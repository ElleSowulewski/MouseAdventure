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
using System.Windows.Shapes;
using MouseAdventure.DataLayer;

namespace MouseAdventure.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;
        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            InitializeComponent();
            SetButtonContent();
        }

        private void button_Help_Click(object sender, RoutedEventArgs e)
        {
            Help helpWindow = new Help();
            helpWindow.ShowDialog();
        }

        private void button_Quit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SetButtonContent()
        {
            choiceA.Content = "Stay Here";
            choiceB.Content = "Continue";
        }

        private void button_choiceB_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.OnPlayerMove();
        }

    }
}
