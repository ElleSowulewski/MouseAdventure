using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    public class GameItem
    {
        // base class for all game items

        #region PROPERTIES

        // declare properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion

        #region CONSTRUCTORS

        // constructor
        public GameItem(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        #endregion

        #region METHODS

        // information string. to be overriden
        public virtual string InformationString()
        {
            return $"{Name}: {Description}";

        }

        #endregion
    }
}
