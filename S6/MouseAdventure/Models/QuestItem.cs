using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    // class that inherits from the GameItem parent class

    public class QuestItem : GameItem
    {
        #region FIELDS

        // declare fields

        public string QuestString { get; set; }

        #endregion

        #region CONSTRUCTORS

        // constructor

        public QuestItem(int id, string name, string description, string questString)
            : base(id, name, description)
        {
            QuestString = questString;
        }

        #endregion

        #region METHODS

        // information string that is overriding parent string
        public override string InformationString()
        {
            return $"{Name}: {Description}/n{QuestString}";
        }

        #endregion
    }
}
