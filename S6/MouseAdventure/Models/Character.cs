using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    // base class for all game characters
    public class Character : ObservableObject
    {
        #region ENUMERABLES

        // declare enum for species
        public enum Species
        {
            Human,
            Cat,
            Mouse
        }

        #endregion

        #region FIELDS

        // declare fields

        protected int _id;
        protected string _name;
        protected int _locationId;
        protected Species _species;

        protected Random random = new Random();

        #endregion

        #region PROPERTIES

        // set up properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public Species species
        {
            get { return _species; }
            set { _species = value; }
        }

        #endregion

        #region CONSTRUCTORS

        // default constructor
        public Character()
        {
            // default constructor
        }

        // constructor
        public Character(int id, string name, Species species, int locationId)
        {
            _id = id;
            _name = name;
            _species = species;
            _locationId = locationId;
        }

        #endregion

        #region METHODS

        // virtual string, to be overridden

        public virtual string DefaultString()
        {
            return $"Hello, my name is {_name} and I am a {_species}.";
        }

        #endregion
    }
}
