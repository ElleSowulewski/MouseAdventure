using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    // class that inherits from the GameItem parent class

    public class Defence : GameItem
    {
        #region ENUMS

        // declare enums

        public enum UseType
        {
            Auto,
            Choice
        }

        #endregion

        #region PROPERTIES

        // declare properties

        public UseType Type { get; set; }

        #endregion

        #region CONSTRUCTORS

        // constructor

        public Defence(int id, string name, string description, UseType use)
            : base (id, name, description)
        {
            Type = use;
        }

        #endregion

        #region METHODS

        // string overriding parents information string

        public override string InformationString()
        {
            return $"{Name}: {Description}. It can be used to defend yourself.";
        }

        #endregion

    }
}
