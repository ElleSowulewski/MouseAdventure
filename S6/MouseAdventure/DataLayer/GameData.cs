using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseAdventure.Models;
using System.Collections.ObjectModel;

namespace MouseAdventure.DataLayer
{

    // static class to store the game data set
    public static class GameData
    {

        #region PLAYER
        public static Player PlayerData()
        {
            // sets up default player

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

        #endregion

        #region METHODS

        // gets item by id from standard game items list

        public static GameItem GameItemById(int id)
        { 
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        // gets npc by id from npc list

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }

        #endregion

        #region MESSAGES

        // sets up messages
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "\tInitial Message."
            };
        }

        #endregion

        #region GAME MAP

        // sets up game map and locations within it

        public static Map GameMap()
        {
            Map gameMap = new Map();
            gameMap.StandardGameItems = StandardGameItems();

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 0,
                    Name = "Home",
                    Description = "You are in your cozy little mouse home. You feel the pangs of hunger, you have not\neaten in weeks. " +
                                   "You know there is food in the human's kitchen a few rooms over,\nbut you have been reluctant as it is a dangerous trip. " +
                                   "But it looks like starvation is \nimminent if you do not do something. You decided that you have no choice.\n\n" +
                                   "Well, it is time to go.",
                    result = Location.Result.FAIL,
                    A = "Let's wait...",
                    B = "Let's go!",
                    DeathMessage = ""
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 1,
                    Name = "Livingroom",
                    Description = "You creep out of your mouse hole and poke your head into the spaceous area the humans \noften are in. " +
                                  "As you are about to leave the big feet of a human approaches...",
                    result = Location.Result.FAIL,
                    A = "Hide and wait...",
                    B = "Make a run for it!",
                    DeathMessage = "Your nervousness prevented you from ever leaving your home. You \neventually starved to death."
                }
                ) ;

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 2,
                    Name = "Livingroom",
                    Description = "As you sprint out of your home, you are stepped on by the human. You scramble \ninside and catch your " +
                                  "breath. Thanks to the thimble on your head you weren't seriously \ninjured, but the thimble broke. The human is " +
                                  "doing something in the room and isn't \nleaving. You have no choice but to continue, or you could be waiting all day.",
                    result = Location.Result.PASS,
                    A = "Sneak under the furniture.",
                    B = "Sneak along the walls.",
                    DeathMessage = "Sneaking along the walls put you too far out into the open. You \nwere spotted by the human who then squished you with a book."
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 3,
                    Name = "Livingroom",
                    Description = "You run to the nearest sofa and dive under it. It is dusty, but in among the dust there \nis a toothpick. " +
                                  "Maybe it could be useful?",
                    result = Location.Result.FAIL,
                    A = "Catch your breath.",
                    B = "Let's continue.",
                    DeathMessage = "You decided to take a break to catch your breath. You must have \nwaited too long, a cat wandered into " +
                                   "the room and snatched you out \nfrom your hiding place. You were eaten.",
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(01)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 4,
                    Name = "Livingroom",
                    Description = "You continue to make your way through the room by sneaking under the furniture. \nSuddenly, a glass marble " +
                                  "hits the floor and rolls under the sofa and next to you.",
                    result = Location.Result.PASS,
                    A = "Scurry away.",
                    B = "Freeze and wait.",
                    DeathMessage = "Staying next to the marble wasn't a good idea. The searching \nhand grabbed you and pulled you out from" +
                                   " your hiding place. \nIn fear, you bit the hand the hand and it dropped you. \nYou broke your neck from the fall."
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 5,
                    Name = "Livingroom",
                    Description = "You scamble to get away from the marble, and just in time. A big human hand reaches \nunder, searching for the " +
                                  "marble. It barely misses touching you before finding the marble \nand picking it up. After letting your heart " +
                                  "settle, you realize you are very close to the \ndoor leaving the livingroom.",
                    result = Location.Result.FAIL,
                    A = "Give up, go home.",
                    B = "Make a run for it!",
                    DeathMessage = "Fear struck your heart and you decided that this adventure was \ntoo big for you. You went home and starved to death " +
                                   "shortly after."
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 6,
                    Name = "Mouse Den",
                    Description = "You sprint out from under the couch and slip under the door without the human seeing you. \nYou feel proud for" +
                                  "making it this far. You carefully creep down the hallway, following your \nnose to the human kitchen. Suddenly, " +
                                  "you hear a low whistle. You turn to see two mice \nleaning out of a mouse hole in the wall, waving you over. Thankful " +
                                  "for a chance to be in a \nsafe mouse den, you comply. Upon hearing your plan, they offer a needle to defend \nyourself. " +
                                  "You wonder who these mice are.",
                    result = Location.Result.FAIL,
                    A = "Let's wait...",
                    B = "I'm ready to go!",
                    DeathMessage = "",
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(2001),
                        NpcById(2002)
                    },
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(31)
                    }
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 7,
                    Name = "Kitchen",
                    Description = "You creep around the corner to the kitchen. You smell a cat...",
                    result = Location.Result.FAIL,
                    A = "Wait...",
                    B = "It's do or die!",
                    DeathMessage = "As you peered around the kitchen, you were suddenly pounced on \nfrom behind. The cat snuck up on you and " +
                                   "you were caught off guard. \nIt killed you quickly."
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 8,
                    Name = "Kitchen",
                    Description = "You think about your choices. You could go left and sneak along the cupboards, or right \nand behind the trash can.",
                    result = Location.Result.PASS,
                    A = "Left!",
                    B = "Right!",
                    DeathMessage = ""
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 9,
                    Name = "Kitchen",
                    Description = "As you continue your adventure, a cat pounces on you from an unknown location!",
                    result = Location.Result.PASS,
                    A = "Defend yourself!",
                    B = "Struggle!",
                    DeathMessage = "No matter how hard you struggled, the cat overpowered you. \nYou couldn't get away so you were eaten."
                }
                );         

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 10,
                    Name = "Kitchen",
                    Description = "You stab blindly. The cat yowls and lets go, licking it's paw... Thankfully, it sulks off \ninstead of attacking again. " +
                                  "Your weapon broke, but you smell food nearby, on top of the \ncupboards. Maybe you could climb up the side?",
                    result = Location.Result.FAIL,
                    A = "Find a better place.",
                    B = "Try it.",
                    DeathMessage = "The cat snuck up on you as you were focused on finding a way to \nclimb up. It pounced and executed you."
                }
                );

            gameMap.Locations.Add 
                (new Location()
                {
                    Id = 11,
                    Name = "Kitchen",
                    Description = "You manage to clamber your way up the cupboard and onto the counter. You see a \nplate of fruits, but it is on S" +
                                  "the other side of a basin of water. ",
                    result = Location.Result.PASS,
                    A = "Jump across.",
                    B = "Go around.",
                    DeathMessage = "As you creep around the edge of the basin, you step on some water \nand fall in. You never learned how to swim and drown."
                }
                );

            gameMap.Locations.Add
                (new Location()
                {
                    Id = 15,
                    Name = "Kitchen",
                    Description = "As you sneak behind the trash can, something shiny catches your eye. It's a shiny gem.",
                    result = Location.Result.PASS,
                    A = "Focus on our task.",
                    B = "Bring to Charles",
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(21)
                    }
                }
                );

            // set the initial location for the player

            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 0);

            return gameMap;
        }

        #endregion

        #region STANDARD GAME ITEMS

        // sets up list of game items

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Defence(01, "Toothpick", "A toothpick made of wood with pointy ends. \nYou have kept it in your home for emergencies.", Defence.UseType.Choice),
                new Defence(11, "Thimble", "A metal thimble the human uses for sewing. \nIt is big enough to fit on your head. \nYou have kept it in your home for emergencies.", Defence.UseType.Auto),
                new Defence(31, "Needle", "A thin metal needle the human uses for sewing. \nIt is very sharp.", Defence.UseType.Choice),
                new QuestItem(21, "Shiny Gem", "A small polished gem, valued heavily by the other mice", "The other mices' pleas run through your head. You need to return this to them.")
            };
        }

        #endregion

        #region NPCS

        // sets up list of npcs

        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Mouse()
                {
                    Id = 2001,
                    Name = "Alfred",
                    species = Character.Species.Mouse,
                    Description = "Alfred, a brown colored mouse who has grown plump from living near the kitchen says:\n",
                    Messages = new List<string>()
                    {
                        "More mice have gone missing...",
                        "You are welcome to take that needle to protect yourself.",
                        "You plan to go to the kitchen!? The cat is in there!",
                        "You got past the human? Nice job!"
                    }
                },

                new Mouse()
                {
                    Id = 2002,
                    Name = "Charles",
                    species = Character.Species.Mouse,
                    Description = "Charles, an older and wise grey mouse says:\n",
                    Messages = new List<string>()
                    {
                        "Heading to the kitchen are you?",
                        "You best be careful! That cat is prowling in the kitchen.",
                        "Alfred is my younger brother.",
                        "We have lost our precious sacred gem. If you are going to the kitchen, \nkeep your eyes out for it. We need it back."
                    }
                }
            };
        }

        #endregion
    }
}