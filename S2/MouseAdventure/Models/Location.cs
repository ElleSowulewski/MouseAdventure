using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    /// <summary>
    /// class for the game map locations
    /// </summary>
    public class Location
    {
        #region ENUMS


        #endregion

        #region FIELDS

        private int _id;
        private string _name;
        private string _description;

        #endregion

        #region PROPERTIES

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

        #endregion

        #region CONSTRUCTORS

        public Location()
        {
            _id = Id;
            _name = Name;
            _description = Description;
        }

        #endregion

        #region METHODS


        #endregion
    }
}