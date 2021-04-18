using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseAdventure.PresentationLayer;

namespace MouseAdventure.Models
{
    // mouse class inherited from Npc class and uses ISpeak interface

    public class Mouse : Npc, ISpeak
    {
        #region FIELDS

        // declare fields

        Random r = new Random();

        #endregion

        #region PROPERTIES

        // set up properties

        public List<string> Messages { get; set; }

        #endregion

        #region CONSTRUCTORS

        // default constructor
        public Mouse()
        {

        }

        // constructor

        public Mouse(int id, string name, Species species, string description, int locationId, List<string> messages)
            : base(id, name, species, description, locationId)
        {
            Messages = messages;
        }

        #endregion

        #region METHODS

        // speak used with interface
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        // gets a random message for that NPC

        private string GetMessage()
        {
            int messageIndex = GameSessionViewModel.DieRoll(Messages.Count());
            return Messages[messageIndex];
        }

        // string ovveriding parents information string

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        #endregion
    }
}
