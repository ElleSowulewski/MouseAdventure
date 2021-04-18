using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MouseAdventure.Models
{
    // class for the game map locations
    public class Location
    {
        #region ENUMS

        // declare enums

        public enum Result
        {
            PASS,
            FAIL
        }

        #endregion

        #region FIELDS

        // declare fields

        private int _id;
        private string _name;
        private string _description;
        private Result _result;
        private string _A;
        private string _B;
        private string _deathMessage;
        private ObservableCollection<GameItem> _gameItems;
        private ObservableCollection<Npc> _npcs;   

        #endregion

        #region PROPERTIES

        // set up properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Result result
        {
            get { return _result; }
            set { _result = value; }
        }

        public string A
        {
            get { return _A; }
            set { _A = value; }
        }

        public string B
        {
            get { return _B; }
            set { _B = value; }
        }

        public string DeathMessage
        {
            get { return _deathMessage; }
            set { _deathMessage = value; }
        }

        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }

        public ObservableCollection<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }

        #endregion

        #region CONSTRUCTORS

        // constructor

        public Location()
        {
            _id = Id;
            _name = Name;
            _description = Description;
            _result = result;
            _A = A;
            _B = B;
            _deathMessage = DeathMessage;
            _gameItems = new ObservableCollection<GameItem>();
        }

        #endregion

        #region METHODS

        // adds item to location

        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Add(selectedGameItem);
            }

        }

        // removes item from location

        public void RemoveGameItemFromLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Remove(selectedGameItem);
            }
        }

        #endregion
    }
}