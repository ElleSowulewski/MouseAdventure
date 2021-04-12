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
using MouseAdventure.BusinessLayer;
using MouseAdventure.Models;
using MouseAdventure.DataLayer;

namespace MouseAdventure.PresentationLayer
{

    public partial class Lose : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public Lose(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            InitializeComponent();
            setText();
        }

        public void setText()
        {
            death.Content = _gameSessionViewModel.CurrentLocation.DeathMessage;
        }

        private void button_play_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
