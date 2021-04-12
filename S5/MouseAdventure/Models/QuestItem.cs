using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAdventure.Models
{
    public class QuestItem : GameItem
    {
        public string QuestString { get; set; }

        public QuestItem(int id, string name, string description, string questString)
            : base(id, name, description)
        {
            QuestString = questString;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}/n{QuestString}";
        }
    }
}
