using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    public class Mouse : Npc, ISpeak
    {
        Random r = new Random();

        public List<string> Messages { get; set; }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Mouse()
        {

        }

        public Mouse(int id, string name, Species species, string description, int locationId, List<string> messages)
            : base(id, name, species, description, locationId)
        {
            Messages = messages;
        }

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

        private string GetMessage()
        {

            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
