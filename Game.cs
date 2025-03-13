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
        bool IsRoom0Locked = true;
        bool KeyInsertedYet = false;
        
        public Game()
        {
            SetName();
            Room Room0 = new Room("a vast rectangular room with a red, blue and green book on a shelf, at the exit of this room is an iron bolted door,");
            Room Room1 = new Room("an enclosed circular chamber with pedestals on the sides of the room, each holding a helmet of an apparently important person");
            Room Room2 = new Room("a long hallway seeming to stretch forever onwards, at the end lies a battleaxe bejewlled in all riches of gems and gold, still sharp as the day it was made");
            
            RoomList.Add(Room0);
            RoomList.Add(Room1);
            RoomList.Add(Room2);
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
                else if (EnteredName == "again" && TriedChangedLater == true)
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
                    else if (KeyInput == "e")
                    {
                        InGame = true;
                    }
                    else
                    {
                        Console.WriteLine("please input a singular letter in lower case that is shown above");
                    }
                    Console.Clear();
                }
                while (InGame == true)
                {
                    string PlayerInventory = Player1.InventoryContents();
                    Console.Write("what do you wish to do: r = return to menu, e = explore room, m = move, i = inventory: ");
                    KeyInput = Console.ReadLine();
                    if (KeyInput == "r")
                    {
                        InGame = false;
                        Console.WriteLine("you have chosen to return to the menu");
                    }
                    if (KeyInput == "e")
                    {
                        Console.Clear();
                        Console.WriteLine("you see the room before you and it looks like: " + RoomList[currentRoom].GetDescription());
                        if (currentRoom == 0 && PlayerInventory.Contains("odd shaped key") == false)
                        {
                            Console.WriteLine("further, you find a small key that seems like it can fit through that keyhole");
                            IsRoom0Locked = false;
                            Player1.PickUpItem("odd shaped key");
                        }
                    }
                    if (KeyInput == "m")
                    {
                        if (IsRoom0Locked == true)
                        {
                            Console.WriteLine("as you attempt to leave your room, you notice a lock on the door, there must be something in the room that might help");
                        }
                        else
                        {
                            Console.Clear();
                            if (KeyInsertedYet == false)
                            {
                                Console.WriteLine("the lock on the door clicks and falls of once the key is inserted");
                                KeyInsertedYet = true;
                            }
                            Console.Write("how do you wish to move, u = up, d = down");
                            KeyInput = Console.ReadLine();
                            if (KeyInput == "u" && currentRoom != 0)
                            {
                                Console.Clear();
                                Console.WriteLine("you traverse along the corredors and enter a new room.");
                                currentRoom = currentRoom - 1;
                            }
                            else if (KeyInput == "d" && currentRoom != 2)
                            {
                                Console.Clear();
                                Console.WriteLine("you traverse along the corredors and enter a new room.");
                                currentRoom = currentRoom + 1;
                            }
                            else if ((KeyInput == "u" && currentRoom == 0) || (KeyInput == "d" && currentRoom == 2))
                            {
                                Console.WriteLine("you are already at an end of the dungeon, try again");
                            }
                            else
                            {
                                Console.WriteLine("please enter either 'u' or 'd' when moving.");
                            }
                        }
                    }
                    if (KeyInput == "i")
                    {
                        if (PlayerInventory.Length == 0)
                        {
                            Console.WriteLine("your inventory is currently empty");
                        }
                        else
                        {
                            Console.WriteLine("your inventory contains: " + PlayerInventory);
                        }
                    }
                }
            }
        }
    }
}