using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    public abstract class Npc : Character
    {
        public string Description { get; set; }
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

        public Npc()
        {

        }

        public Npc(int id, string name, Species species, string description, int locationId)
            : base(id, name, species, locationId)
        {
            Description = description;
        }

        protected abstract string InformationText();
    }
}
