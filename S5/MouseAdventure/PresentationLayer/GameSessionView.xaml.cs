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
        }

        private void button_Help_Click(object sender, RoutedEventArgs e)
        {
            Help helpWindow = new Help();
            helpWindow.ShowDialog();
        }

        private void item_label_Click(object sender, RoutedEventArgs e)
        {
            ItemDesc itemDescWindow = new ItemDesc(_gameSessionViewModel);
            itemDescWindow.Show();
        }

        private void button_Quit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_talkA_Click(object sender, RoutedEventArgs e)
        {
            if(_gameSessionViewModel.CurrentLocation.Id == 6)
            {
                _gameSessionViewModel.OnPlayerTalkA();
            }           
        }

        private void button_talkC_Click(object sender, RoutedEventArgs e)
        {
            if (_gameSessionViewModel.CurrentLocation.Id == 6)
            {
                _gameSessionViewModel.OnPlayerTalkC();
            }
        }

        private void button_choiceA_Click(object sender, RoutedEventArgs e)
        {

            if (_gameSessionViewModel.DeathA() == true || (_gameSessionViewModel.Index == 10 && _gameSessionViewModel.CheckDefenseItem() == false))
            {
                Visibility = Visibility.Hidden;
                Lose loseWindow = new Lose(_gameSessionViewModel);
                loseWindow.ShowDialog();
                _gameSessionViewModel.ResetRoom();
                Visibility = Visibility.Visible;
            }
            else if (_gameSessionViewModel.Index == 12)
            {
                Visibility = Visibility.Hidden;
                Win1 winWindow = new Win1();
                winWindow.ShowDialog();
                Environment.Exit(0);
            }
            else if (_gameSessionViewModel.DeathA() == false && _gameSessionViewModel.Index <= 13)
            {
                _gameSessionViewModel.OnPlayerMoveA();
            }
        }

        private void button_choiceB_Click(object sender, RoutedEventArgs e)
        {
            
            if (_gameSessionViewModel.DeathB() == true)
            {
                Visibility = Visibility.Hidden;
                Lose loseWindow = new Lose(_gameSessionViewModel);
                loseWindow.ShowDialog();
                _gameSessionViewModel.ResetRoom();
                Visibility = Visibility.Visible;
            }
            else if (_gameSessionViewModel.Index == 13 && _gameSessionViewModel.CheckQuestItem() == true)
            {
                Visibility = Visibility.Hidden;
                Win2 winWindow = new Win2();
                winWindow.ShowDialog();
                Environment.Exit(0);
            }
            else if (_gameSessionViewModel.DeathB() == false && _gameSessionViewModel.Index < 12)
            {
                _gameSessionViewModel.OnPlayerMoveB();
            }
        }
        private void pick_Button_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.AddItemToInventory();
        }

    }
}
