using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseAdventure.Models;
using System.Collections.ObjectModel;

namespace MouseAdventure.DataLayer
{
    /// <summary>
    /// static class to store the game data set
    /// </summary>
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Mousey",
                species = Character.Species.Mouse,
                LocationId = 0,
                Lives = 1,
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemById(01)
                }
                
            };
            
        }

        public static GameItem GameItemById(int id)
        { 
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        public static List<string> InitialMessages()
        {
            
            return new List<string>()
            {
                "\tInitial Message."
            };
        }

        public static Map GameMap()
        {
            Map gameMap = new Map();
            gameMap.StandardGameItems = StandardGameItems();

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 0,
                    Name = "Home",
                    Description = "Your Home"
                }
                );
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 1,
                    Name = "Livingroom",
                    Description = "The Livingroom",
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(11)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 2,
                    Name = "Mouse Den",
                    Description = "The mouse den",
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(31)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 3,
                    Name = "Kitchen",
                    Description = "The Kitchen",
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(21)
                    }
                }
                );

            //
            // set the initial location for the player
            //
            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 0);

            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Defence(01, "Toothpick", "A toothpick made of wood with pointy ends. You have kept it in your home for emergencies.", Defence.UseType.Choice),
                new Defence(11, "Thimble", "A metal thimble the human uses for sewing. It is big enough to fit on your head.", Defence.UseType.Auto),
                new Defence(31, "Needle", "A thin metal needle the human uses for sewing. It is very sharp.", Defence.UseType.Choice),
                new QuestItem(21, "Shiny Gem", "A small polished gem, valued heavily by the other mice", "The other mices' pleas run through your head. You need to return this to them.")
            };
        }
    }
}