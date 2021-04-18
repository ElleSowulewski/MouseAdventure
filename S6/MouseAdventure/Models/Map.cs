using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MouseAdventure.DataLayer;

namespace MouseAdventure.Models
{
    // game map class
    public class Map
    {
        #region FIELDS

        // declare fields

        private List<Location> _locations;
        private Location _currentLocation;
        private List<GameItem> _standardGameItems;

        #endregion

        #region PROPERTIES

        // set up properties

        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }
        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }

        #endregion

        #region CONSTRUCTORS

        // constructor

        public Map()
        {
            _locations = new List<Location>();
        }

        #endregion

    }
}
