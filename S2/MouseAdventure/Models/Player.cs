using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    /// <summary>
    /// player class
    /// </summary>
    public class Player : Character
    {
        #region FIELDS

        private int _lives;

        #endregion

        #region PROPERTIES

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        #endregion

        #region CONSTRUCTORS
        public Player()
        {

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

        /// <summary>
        /// override the default greeting in the Character class to include the job title
        /// set the proper article based on the job title
        /// </summary>
        /// <returns>default greeting</returns>
        public override string DefaultString()
        {
            return $"Hello, my name is {_name} and I am mouse on the quest for food.";
        }

        #endregion

        #region EVENTS



        #endregion

    }
}