using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
        private string _currentLocationInformation;

        private GameItem _currentGameItem;
        private Npc _currentNpc;

        private Random random = new Random();

        private bool isDead = false;
        private int _index = 0;

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
                _currentLocationInformation = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set
            {
                _currentLocationName = value;
                OnPlayerMoveB();
                OnPropertyChanged("CurrentLocation");
            }
        }

        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }

        public Npc CurrentNpc
        {
            get { return _currentNpc; }
            set
            {
                _currentNpc = value;
                OnPropertyChanged(nameof(CurrentNpc));
            }
        }

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
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
            _player.AddGameItemToInventory(GameData.GameItemById(11));
            _currentLocation = _gameMap.CurrentLocation;
        }

        #endregion

        #region METHODS
      
        public void OnPlayerMoveA()
        {
            if (Index < 12)
            {
                CurrentLocation = _gameMap.Locations[Index];
                if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
                {
                    CurrentGameItem = CurrentLocation.GameItems[0];
                }
                if (Index == 13)
                {
                    CurrentLocation = _gameMap.Locations[9];
                    Index = 10;
                }
                if (Index == 10)
                {
                    GameItem selectedGameItem = _player.Inventory[0] as GameItem;
                    _player.RemoveGameItemFromInventory(selectedGameItem);
                }
                if (Index == 7)
                {
                    Index = 6;
                    CurrentLocation = _gameMap.Locations[Index];
                }
            }
            else if (Index == 13)
            {
                CurrentLocation = _gameMap.Locations[9];
                Index = 10;
            }
            ++Index;

            CurrentLocationInformation = "";

        }

        public void OnPlayerMoveB()
        {
            if (Index < 12)
            {
                CurrentLocation = _gameMap.Locations[Index];
                if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
                {
                    CurrentGameItem = CurrentLocation.GameItems[0];
                }               
                if (Index == 2)
                {
                    GameItem selectedGameItem = _player.Inventory[0] as GameItem;
                    _player.RemoveGameItemFromInventory(selectedGameItem);
                }
                if (Index == 9)
                {
                    CurrentLocation = _gameMap.Locations[12];
                    Index = 12;
                }
                ++Index;
                
            }
            CurrentLocationInformation = "";
        }

        public bool DeathA()
        {
            if (CurrentLocation.result == Location.Result.FAIL && CheckRoom(Index) == false)
            {
                isDead = true;
                return isDead;
            }
            else
            {
                isDead = false;
                return isDead;
            }
        }

        public bool DeathB()
        {
            if (CurrentLocation.result == Location.Result.PASS && CheckRoom(Index) == false)
            {
                isDead = true;
                return isDead;
            }
            else
            {
                isDead = false;
                return isDead;
            }
        }

        public void AddItemToInventory()
        {
            if (CurrentLocation.GameItems.Count != 0)
            {
                if (_player.Inventory.Count != 0)
                {
                    GameItem selectedItem = _player.Inventory[0] as GameItem;
                    _player.RemoveGameItemFromInventory(selectedItem);
                    _currentLocation.AddGameItemToLocation(selectedItem);
                }             
                GameItem selectedGameItem = CurrentLocation.GameItems[0] as GameItem;
                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);
            }
        }

        public void OnPlayerTalkA()
        {
            CurrentNpc = CurrentLocation.Npcs[0];
            if (CurrentNpc != null && CurrentNpc is ISpeak)
            {
                ISpeak speakingNpc = CurrentNpc as ISpeak;
                CurrentLocationInformation = CurrentNpc.Description + '"' + speakingNpc.Speak() + '"';
            }

            Console.WriteLine(CurrentLocationInformation);
        }

        public void OnPlayerTalkC()
        {
            CurrentNpc = CurrentLocation.Npcs[1];
            if (CurrentNpc != null && CurrentNpc is ISpeak)
            {
                ISpeak speakingNpc = CurrentNpc as ISpeak;
                CurrentLocationInformation = CurrentNpc.Description + '"' + speakingNpc.Speak() + '"';
            }

            Console.WriteLine(CurrentLocationInformation);
        }

        #region HELPER METHODS

        private int DieRoll(int num)
        {
            return random.Next(1, num + 1);
        }

        private bool CheckRoom(int Index)
        {
            int[] safeRooms = { 0, 7, 9, 12, 13};

            foreach (int num in safeRooms)
            {
                if(Index == num)
                {
                    return true;
                }
            }

            return false;
        }

        public void ResetRoom()
        {
            if (Index< 6)
            {
                Index = 0;
                CurrentLocation = _gameMap.Locations[Index];
                if(_player.Inventory.Count != 0)
                {
                    GameItem selectedItem = _player.Inventory[0] as GameItem;
                    _player.RemoveGameItemFromInventory(selectedItem);
                }
                _player.AddGameItemToInventory(GameData.GameItemById(11));
                _gameMap.Locations[3].AddGameItemToLocation(GameData.GameItemById(01));
            }
            else
            {
                Index = 6;
                CurrentLocation = _gameMap.Locations[Index];
                if (_player.Inventory.Count != 0)
                {
                    GameItem selectedItem = _player.Inventory[0] as GameItem;
                    _player.RemoveGameItemFromInventory(selectedItem);
                }
                if (_currentLocation.GameItems.Count == 0)
                {
                    _gameMap.Locations[6].AddGameItemToLocation(GameData.GameItemById(31));
                }
                
            }

            CurrentLocationInformation = "";

        }

        public bool CheckQuestItem()
        {
            if (_player.Inventory.Count != 0)
            {
                GameItem selectedItem = _player.Inventory[0] as GameItem;
                if (selectedItem.Id == 21)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckDefenseItem()
        {
            if (_player.Inventory.Count != 0)
            {
                GameItem selectedItem = _player.Inventory[0] as GameItem;
                if (selectedItem.Id == 01 || selectedItem.Id == 31)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #endregion

        #region EVENTS

        #endregion
    }
}
