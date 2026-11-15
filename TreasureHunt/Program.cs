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

            //LIBRARY
            Clue libraryClue = new Clue(
                "I have a spine, but I am not an animal. I stand on a shelf, but I am not a trophy. I tell stories, but don't make a sound.",
                "you can find thousands of these in the library.",
                "Book");

            Treasure libraryTreasure = new Treasure(
                "Tome of Knowledge",
                "An ancient tome containing the wisdom of generations of students.",
                10);

            Location library = new Location("Library", libraryClue, libraryTreasure);

            //COMPUTER LAB
            Clue computerClue = new Clue(
                "I move an arrow without a bow. I scroll through pages I'll never read. And I'm the only rodent allowed on your desk.",
                "You use me to click on things.",
                "Mouse");

            Treasure computerTreasure = new Treasure(
                "Ring of Telekinesis",
                "A mysterious ring that allows its wearer to move objects with their mind.",
                15);

            Location computerLab = new Location("Computer Lab", computerClue, computerTreasure);

            //CANTEEN
            Clue canteenClue = new Clue(
                "You can find me in the middle of the road, yet I live in a kitchen drawer.",
                "You use me when eating",
                "Fork");

            Treasure canteenTreasure = new Treasure(
                "Potion of Instant Stamina",
                "A magical potion that instantly restores the drinker's energy.",
                10);

            Location canteent = new Location("Canteen", canteenClue, canteenTreasure);

            //STUDENT UNION
            Clue unionClue = new Clue(
                "I am a pool with no water, a table with no chairs, and a pair of trousers with six empty pockets.",
                "You use a cue to play on me.",
                "Pool Table");

            Treasure unionTreasure = new Treasure(
                "Orb of F8",
                "A mysterious orb that reveals glimpses of the future, although its answers aren't always reliable.",
                20);

            Location studentUnion = new Location("Student Union", unionClue, unionTreasure);

            //OUTPUT
            Console.WriteLine("Welcome to the ATU Treasure Hunt!");
            Console.WriteLine();

            Console.WriteLine($"Location: {library.Name}");
            Console.WriteLine(library.Clue.Question);

            if (library.Clue.TryAnswer("Magazine"))
            {
                player.AddTreasure(libraryTreasure);
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            if (library.Clue.TryAnswer("Book"))
            {
                Console.WriteLine("Correct!");
                player.AddTreasure(libraryTreasure);
            }

            Console.WriteLine();

            Console.WriteLine($"Location: {computerLab.Name}");
            Console.WriteLine(computerLab.Clue.Question);

            if (computerLab.Clue.TryAnswer("Mouse"))
            {
                Console.WriteLine("Correct!");
                player.AddTreasure(computerLab.Treasure);
            }

            Console.WriteLine();

            player.ShowTreasures();
        }
    }
}
