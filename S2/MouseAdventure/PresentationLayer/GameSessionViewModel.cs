using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MouseAdventure.Models;
using MouseAdventure.DataLayer;

namespace MouseAdventure.PresentationLayer
{
    /// <summary>
    /// view model for the game session view
    /// </summary>
    public class GameSessionViewModel : ObservableObject
    {
        #region FIELDS

        private Player _player;
        private List<string> _messages;

        private Map _gameMap;
        private Location _currentLocation;
        private string _currentLocationName;

        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
        }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set
            {
                _currentLocationName = value;
                OnPlayerMove();
                OnPropertyChanged("CurrentLocation");
            }
        }

        #endregion

        #region CONSTRUCTORS 

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            List<string> initialMessages,
            Map gameMap)
        {
            _player = player;
            _messages = initialMessages;
            _gameMap = gameMap;

            _currentLocation = _gameMap.CurrentLocation;
        }

        #endregion

        #region METHODS


        /// <summary>
        /// player move event handler
        /// </summary>
        /// 
        int Index = 0;
        public void OnPlayerMove()
        {
            if (Index < 3)
            {
                Index++;
                CurrentLocation = _gameMap.Locations[Index];
            }          
            
        }

        #endregion

        #region EVENTS

        #endregion
    }
}
