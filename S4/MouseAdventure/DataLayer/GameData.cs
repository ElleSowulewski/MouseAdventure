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

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
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
                    Description = "Your cozy little mouse home."
                }
                );
            gameMap.Locations.Add
                (new Location()
                {
                    Id = 1,
                    Name = "Livingroom",
                    Description = "A spaceous area the humans often are in.",
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
                    Description = "This den in the wall is the home of many mice.",
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(31)
                    },
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(2001),
                        NpcById(2002)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 3,
                    Name = "Kitchen",
                    Description = "An area with lots of human food. You smell a cat...",
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
                new Defence(01, "Toothpick", "A toothpick made of wood with pointy ends. \nYou have kept it in your home for emergencies.", Defence.UseType.Choice),
                new Defence(11, "Thimble", "A metal thimble the human uses for sewing. \nIt is big enough to fit on your head.", Defence.UseType.Auto),
                new Defence(31, "Needle", "A thin metal needle the human uses for sewing. \nIt is very sharp.", Defence.UseType.Choice),
                new QuestItem(21, "Shiny Gem", "A small polished gem, valued heavily by the other mice", "The other mices' pleas run through your head. You need to return this to them.")
            };
        }

        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Mouse()
                {
                    Id = 2001,
                    Name = "Alfred",
                    species = Character.Species.Mouse,
                    Description = "A brown colored mouse who has grown plump from living near the kitchen.",
                    Messages = new List<string>()
                    {
                        "More mice have gone missing...",
                        "You best be careful! That cat is prowling in the kitchen.",
                        "You plan to go to the kitchen!? The cat is in there!",
                        "You got past the human? Nice job!"
                    }
                },

                new Mouse()
                {
                    Id = 2002,
                    Name = "Charles",
                    species = Character.Species.Mouse,
                    Description = "An older grey mouse, other mice look up to him.",
                    Messages = new List<string>()
                    {
                        "Heading to the kitchen are you?",
                        "Alfred is my younger brother.",
                        "We have lost our precious sacred gem. If you are going to the kitchen, \nkeep your eyes out for it. We need it back."
                    }
                }
            };
        }
    }
}