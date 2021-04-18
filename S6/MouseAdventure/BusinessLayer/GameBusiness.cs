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
using MouseAdventure.BusinessLayer;
using MouseAdventure.PresentationLayer;
using MouseAdventure.Models;

namespace MouseAdventure.BusinessLayer
{
    /// business logic layer class
    /// manages windows and interacts with the data layer
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        GameSessionView _gameSessionView;
        bool _newPlayer = true;
        Player _player = new Player();
        PlayerSetUpView _playerSetupView = null;
        List<string> _messages;
        Map _gameMap;

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        // handles the set up player window

        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetUpView(_player);
                _playerSetupView.ShowDialog();
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

        /// initializes data set
        private void InitializeDataSet()
        {
            _messages = GameData.InitialMessages();
            _gameMap = GameData.GameMap();
        }

        /// creates view model with data set
        private void InstantiateAndShowView()
        {
            // instantiate the view model and initialize the data set
            _gameSessionViewModel = new GameSessionViewModel(_player, _messages, _gameMap);
            _gameSessionView = new GameSessionView(_gameSessionViewModel);

            _gameSessionView.DataContext = _gameSessionViewModel;

            _gameSessionView.Show();

            _playerSetupView.Close();
            
        }

    }


}
