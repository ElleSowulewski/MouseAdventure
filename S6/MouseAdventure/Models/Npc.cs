using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    // base class inheriting from character class
    public abstract class Npc : Character
    {
        #region FIELDS

        // declare properties

        public string Description { get; set; }

        #endregion

        #region PROPERTIES
        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }

        #endregion

        #region CONSTRUCTORS

        // default constructor

        public Npc()
        {

        }

        // constructor

        public Npc(int id, string name, Species species, string description, int locationId)
            : base(id, name, species, locationId)
        {
            Description = description;
        }

        #endregion

        #region METHODS

        protected abstract string InformationText();

        #endregion
    }
}
