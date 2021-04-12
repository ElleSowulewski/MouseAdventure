using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MouseAdventure;
using MouseAdventure.Models;
using MouseAdventure.DataLayer;

namespace MouseAdventure.PresentationLayer
{
    /// <summary>
    /// view model for the game session view model
    /// </summary>
    public class GameSessionViewModel : ObservableObject
    {
        #region FIELDS

        private Player _player;
        private List<string> _messages;

        private Map _gameMap;
        private Location _currentLocation;
        private string _currentLocationName;

        private GameItem _currentGameItem;

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

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
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
            _player.AddGameItemToInventory(GameData.GameItemById(01));
            _currentLocation = _gameMap.CurrentLocation;       
            _player.UpdateInventoryCategories();
        }

        #endregion

        #region METHODS

        int Index = 0;
        public void OnPlayerMove()
        {
            if (Index < 3)
            {
                Index++;
                CurrentLocation = _gameMap.Locations[Index];
                CurrentGameItem = _gameMap.Locations[Index].GameItems[0];
                Console.WriteLine(CurrentGameItem);
            }                 
        }

        public void AddItemToInventory()
        {
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);
            }            
        }

        public void RemoveItemFromInventory()
        {
            if (_currentGameItem != null)
            {
                GameItem selectedGameItem = _player.Inventory[0] as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);
            }
        }

        #endregion

        #region EVENTS

        #endregion
    }
}
