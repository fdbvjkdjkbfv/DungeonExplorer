using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        public static string EnteredName;

        public List<Room> RoomList = new List<Room>();

        private int currentRoom;
        private Player Player1;
        private Room Room1;
        
        bool SuitableName = false;
        bool TriedChangedLater = false;
        
        public Game()
        {
            // Initialize the game with one room and one player
            SetName();
        }

        public void SetName()
        {
            while (SuitableName == false)
            {
                Console.Write("enter your name (it cannot be changed later): ");
                EnteredName = Console.ReadLine();
                if (EnteredName == "changed later")
                {
                    Console.WriteLine("you are hilarious, try again");
                    TriedChangedLater = true;
                    SetName();
                }
                if (EnteredName == "again" && TriedChangedLater == true)
                {
                    Console.WriteLine("hysterical, go again");
                    SetName();
                }
                else
                {
                    SuitableName = true;
                }
            }

            Player1 = new Player(EnteredName, 10);
        }
        public void Start()
        { 
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            currentRoom = 0;

            while (playing)
            {
                if (InGame == false)
                {
                    Console.Write("what do you wish to do: q = quit, e = enter game: ");
                    KeyInput = Console.ReadLine();
                    if (KeyInput == "q")
                    {
                        Console.WriteLine("you have chosen to quit");
                        playing = false;
                    }
                    if (KeyInput == "e")
                    {
                        InGame = true;
                    }
                    else
                    {
                        Console.WriteLine("please input a singular letter in lower that is shown above");
                    }
                if (InGame == true)
                    {
                        while (InGame == true)
                        {
                            Console.Write("what do you wish to do: r = return to menu, e = explore room, m = move, i = inventory: ");
                            KeyInput = Console.ReadLine();
                            if (KeyInput == "r")
                            {
                                InGame = false;
                                Console.WriteLine("you have chosen to return to the menu");
                            }
                            if (KeyInput == "e")
                            {
                                Console.WriteLine("the room before you looks like: " + RoomList[currentRoom].GetDescription());
                            }
                            if (KeyInput == "m")
                            {
                                Console.WriteLine("to be implemented later");
                            }
                            if (KeyInput == "i")
                            {
                                Console.WriteLine("to be implemented later");
                            }
                        }
                    }
                }
            }
        }
    }
}