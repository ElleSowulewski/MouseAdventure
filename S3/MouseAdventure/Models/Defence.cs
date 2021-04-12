using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    public class Defence : GameItem
    {
        public enum UseType
        {
            Auto,
            Choice
        }

        public UseType Type { get; set; }

        public Defence(int id, string name, string description, UseType use)
            : base (id, name, description)
        {
            Type = use;
        }

        public override string InformationString()
        {
            //Instructions say to have override InformationString method include
            //theunique properties. I do not know how to do it in this case.
            return $"{Name}: {Description}";
        }
    }
}
