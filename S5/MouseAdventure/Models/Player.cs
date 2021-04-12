using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace MouseAdventure.Models
{
    /// <summary>
    /// player class
    /// </summary>
    public class Player : Character
    {
        #region FIELDS

        private int _lives;
        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _defence;
        private ObservableCollection<GameItem> _questItem;

        #endregion

        #region PROPERTIES

        public int Lives
        {
            get { return _lives; }
            set
            {
                _lives = value;
                OnPropertyChanged(nameof(Lives));
            }
        }

        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public ObservableCollection<GameItem> Defence
        {
            get { return _defence; }
            set { _defence = value; }
        }

        public ObservableCollection<GameItem> QuestItem
        {
            get { return _questItem; }
            set { _questItem = value; }
        }

        #endregion

           #region CONSTRUCTORS
        public Player()
        {
            _inventory = new ObservableCollection<GameItem>();
            _defence = new ObservableCollection<GameItem>();
            _questItem = new ObservableCollection<GameItem>();
        }

        public Player(int id, string name, Species species, int locationId, int lives)
        {
            _id = id;
            _name = name;
            _species = species;
            _locationId = locationId;
            _lives = lives;
        }

        #endregion

        #region METHODS

        public void UpdateInventoryCategories()
        {
            Defence.Clear();
            QuestItem.Clear();

            foreach (var gameItem in _inventory)
            {
                if (gameItem is Defence) Defence.Add(gameItem);
                if (gameItem is QuestItem) QuestItem.Add(gameItem);
            }
        }

        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }

            UpdateInventoryCategories();
        }

        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Remove(selectedGameItem);
            }

            UpdateInventoryCategories();
        }

        public override string DefaultString()
        {
            return $"Hello, my name is {_name} and I am mouse on the quest for food.";
        }

        #endregion

        #region EVENTS



        #endregion

    }
}