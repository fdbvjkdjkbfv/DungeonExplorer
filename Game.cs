using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        public static string EnteredName;

        public List<Room> RoomList = new List<Room>();

        private int currentRoom;
        private Player Player1;
        
        bool SuitableName = false;
        bool TriedChangedLater = false;
        string KeyInput;
        bool InGame = false;
        
        public Game()
        {
            // Initialize the game with one room and one player
            SetName();
            Room Room0 = new Room("description0");
            Room Room1 = new Room("description1");
            Room Room2 = new Room("description2");
            Room Room3 = new Room("description3");
            Room Room4 = new Room("description4");
            Room Room5 = new Room("description5");
            Room Room6 = new Room("description6");
            Room Room7 = new Room("description7");
            Room Room8 = new Room("description8");
            Room Room9 = new Room("description9");
            
            RoomList.Add(Room0);
            RoomList.Add(Room1);
            RoomList.Add(Room2);
            RoomList.Add(Room3);
            RoomList.Add(Room4);
            RoomList.Add(Room5);
            RoomList.Add(Room6);
            RoomList.Add(Room7);
            RoomList.Add(Room8);
            RoomList.Add(Room9);
            //Console.WriteLine(RoomList[1].GetDescription());
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