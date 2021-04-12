using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseAdventure.Models;

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
                Lives = 1
            };
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
                    Description = "The Livingroom"
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 2,
                    Name = "Mouse Den",
                    Description = "The mouse den"
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 3,
                    Name = "Kitchen",
                    Description = "The Kitchen"
                }
                );

            //
            // set the initial location for the player
            //
            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 0);

            return gameMap;
        }


    }
}