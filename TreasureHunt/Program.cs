using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Gerald");

            //--- Creating the clues, treasures, and locations ---
            //LIBRARY
            Clue libraryClue = new Clue(
                "I have a spine, but I am not an animal. I stand on a shelf, but I am not a trophy. I tell stories, but don't make a sound.",
                "you can find thousands of these in the library.",
                "Book");

            Treasure libraryTreasure = new Treasure(
                "Tome of Knowledge",
                "An ancient tome containing the wisdom of generations of students.",
                10);

            Location library = new Library(libraryClue, libraryTreasure);

            //COMPUTER LAB
            Clue computerClue = new Clue(
                "I move an arrow without a bow. I scroll through pages I'll never read. And I'm the only rodent allowed on your desk.",
                "You use me to click on things.",
                "Mouse");

            Treasure computerTreasure = new Treasure(
                "Ring of Telekinesis",
                "A mysterious ring that allows its wearer to move objects with their mind.",
                15);

            Location computerLab = new ComputerLab(computerClue, computerTreasure);

            //CANTEEN
            Clue canteenClue = new Clue(
                "You can find me in the middle of the road, yet I live in a kitchen drawer.",
                "You use me when eating",
                "Fork");

            Treasure canteenTreasure = new Treasure(
                "Potion of Instant Stamina",
                "A magical potion that instantly restores the drinker's energy.",
                10);

            Location canteen = new Canteen(canteenClue, canteenTreasure);

            //STUDENT UNION
            Clue unionClue = new Clue(
                "I am a pool with no water, a table with no chairs, and a pair of trousers with six empty pockets.",
                "You use a cue to play on me.",
                "Pool Table");

            Treasure unionTreasure = new Treasure(
                "Orb of F8",
                "A mysterious orb that reveals glimpses of the future, although its answers aren't always reliable.",
                20);

            Location studentUnion = new StudentUnion(unionClue, unionTreasure);

            //BUS STOP
            Location busStop = new BusStop();

            //CONNECT LOCATIONS
            library.AddExit("east", computerLab);
            computerLab.AddExit("west", library);

            computerLab.AddExit("south", canteen);
            canteen.AddExit("north", computerLab);

            canteen.AddExit("west", studentUnion);
            studentUnion.AddExit("east", canteen);

            studentUnion.AddExit("south", busStop);
            busStop.AddExit("north", studentUnion);

            //------------- GAME LOGIC --------------
            player.CurrentLocation = library;

            Console.WriteLine("=== THE GREAT ATU TREASURE HUNT ===");
            Console.WriteLine("Freshers' Week! Clubs & Socs have hidden treasures around campus.");
            Console.WriteLine("Find all 4 and reach the bus stop before the last bus (20 turns).");
            Console.WriteLine("Prize: a parking space for the whole year. Nobody has ever won it.");
            Console.WriteLine("Type help for commands.");
            Console.WriteLine();

            Console.WriteLine($"-- {player.CurrentLocation.Name} --");
            Console.WriteLine(player.CurrentLocation.Describe());
            Console.WriteLine($"Clue: {player.CurrentLocation.Clue.Question}");
            player.CurrentLocation.ShowExits();

            bool playing = true;
            int turnsRemaining = 20;

            //Runs the game until player wins, loses, or quits
            while (playing)
            {
                Console.WriteLine();
                Console.Write("> ");
                string command = Console.ReadLine().ToLower().Trim();

                //LOOK
                if (command == "look")
                {
                    Console.WriteLine($"-- {player.CurrentLocation.Name} --");
                    Console.WriteLine(player.CurrentLocation.Describe());
                    if (player.CurrentLocation.Clue != null)
                    {
                        Console.WriteLine($"Clue: {player.CurrentLocation.Clue.Question}");
                    }
                    player.CurrentLocation.ShowExits();
                }
                //GO [DIRECTION]
                else if (command.StartsWith("go "))
                {
                    string direction = command.Substring(3);
                    Location nextLocation = player.CurrentLocation.FindExit(direction);

                    if (nextLocation != null)
                    {
                        player.CurrentLocation = nextLocation;
                        turnsRemaining--;

                        Console.WriteLine($"-- {player.CurrentLocation.Name} --");
                        Console.WriteLine(player.CurrentLocation.Describe());
                        if (player.CurrentLocation.Clue != null)
                        {
                            Console.WriteLine($"Clue: {player.CurrentLocation.Clue.Question}");
                        }
                        player.CurrentLocation.ShowExits();
                        Console.WriteLine($"Turns until the last bus: {turnsRemaining}");

                        if (player.CurrentLocation == busStop)
                        {
                            if (player.TreasureCount == 4 && turnsRemaining >= 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Congratualtions! You collected all 4 treasures!");
                                Console.WriteLine("You made it to the last bus on time!");
                                Console.WriteLine($"Final score: {player.Score}");
                                Console.WriteLine("You've won a parking space for the whole year!");
                                playing = false;
                            }
                            else if (player.TreasureCount < 4)
                            {
                                Console.WriteLine("You still need to collect all four treasures before finishing!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't go that way!");
                    }
                }
                //ANSWER [ANSWER]
                else if (command.StartsWith("answer "))
                {
                    string answer = command.Substring(7);

                    if (player.CurrentLocation.Clue == null)
                    {
                        Console.WriteLine("There is no clue to solve here!");
                    }
                    else if (player.HasTreasure(player.CurrentLocation.Treasure))
                    {
                        Console.WriteLine("You already solved this clue!");
                    }
                    else
                    {
                        turnsRemaining--;

                        if (player.CurrentLocation.Clue.TryAnswer(answer))
                        {
                            player.AddTreasure(player.CurrentLocation.Treasure, player.CurrentLocation.Clue.HintUsed);

                            Console.WriteLine($"Correct! You found the {player.CurrentLocation.Treasure.Name}!");
                            Console.WriteLine($"Treasures collected: {player.TreasureCount}/4");
                        }
                        else
                        {
                            Console.WriteLine("Not quite! Try again, or type hint.");
                        }
                        Console.WriteLine($"Turns until the last bus: {turnsRemaining}");
                    }
                }
                //HINT
                else if (command == "hint")
                {
                    if (player.CurrentLocation.Clue == null)
                    {
                        Console.WriteLine("There is no hint available here!");
                    }
                    else if (player.HasTreasure(player.CurrentLocation.Treasure))
                    {
                        Console.WriteLine("You already solved this clue!");
                    }
                    else
                    {
                        Console.WriteLine($"Hint: {player.CurrentLocation.Clue.Hint}");

                        if (!player.CurrentLocation.Clue.HintUsed)
                        {
                            player.CurrentLocation.Clue.UseHint();
                            Console.WriteLine("Using a hint takes 5 points off this treasure");
                        }
                    }
                }
                else if (command == "treasures")
                {
                    player.ShowTreasures();
                }
                else if (command == "score")
                {
                    Console.WriteLine($"Current score: {player.Score}");
                }
                //HELP
                else if (command == "help")
                {
                    Console.WriteLine("look - Look around your current location");
                    Console.WriteLine("go [direction] - Move to another location");
                    Console.WriteLine("answer [answer] - Attempt to solve the current clue");
                    Console.WriteLine("hint - Get a hint (costs 5 points)");
                    Console.WriteLine("treasures - Shows collected treasures");
                    Console.WriteLine("score - Shows your current score");
                    Console.WriteLine("quit - Exit the game");
                }
                //QUIT
                else if (command == "quit")
                {
                    Console.WriteLine("Thanks for playing!");
                    playing = false;
                }
                else
                {
                    Console.WriteLine("Unknown command. Type help for commands.");
                }

                if (turnsRemaining <= 0)
                {
                    Console.WriteLine("You've run out of turns! The last bus has left.");
                    Console.WriteLine("Game Over");
                    playing = false;
                }
            }

        }
    }
}
