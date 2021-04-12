using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    public class GameItem
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Information
        {
            get
            {
                return InformationString();
            }
        }

        public GameItem(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public virtual string InformationString()
        {
            return $"{Name}: {Description}";

        }
    }
}
