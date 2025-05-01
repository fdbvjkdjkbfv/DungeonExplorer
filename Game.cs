using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        public List<Room> RoomList = new List<Room>();
        public List<string> LootList = new List<string>();

        private int CurrentRoom;
        private Player Player1;
        string KeyInput;
        bool InGame = false;

        public Game()
        {
            Testing testing = new Testing();
            //As you desecend the stairs from the bathhouse tarina mentioned, you examine that the quality of the stonework is of considerably worse quality
            Player1 = new Player(testing.SetName(), 10, 2);
            Room DungeonEntrance = new Room("as you examine this room you find that its flooded to a distance of a foot high with grime all over the walls and ferrous sort of smell, at the end of the room is a door made of rotten looking wood planks, while decrepid it seems to still have a lock on it", true);
            Room HexagonalRoom = new Room("you enter a hexagonal room, almost empty but not bereft of decor, for on the door to the east is a face bearing  a tall armoured man wearing a bucket helm, his right gauntlet painted black and clutching a set of shackles, you recognise this image as the visage of Bane, the god of tyranny", false);
            Room BanesRoom = new Room("as you enter this room you notice the far eastern part is unlit with the floor flooded and the walls braced, a man wielding a mace, wearing a bucket helm and wading in the murky water turns his gaze from a corpse, just recently killed, to meet your gaze", false);
            Room BhaalsAltar = new Room("in the room there are 3 wooden beams from floor to cieling, a stone altar at the north of the room laiden with blood spilt from an offering days ago, above that altar is hanging  three foot tall steel mask, laiden with red gem bejewelled tears, and you see this bears likeness to bhaal the lord of murder", false);
            Room BanesPrison = new Room("in this room, the walls and floor engulfed by spattering of blood, on the floor are the bodies of a wood elf and a tiefling, both seemed to be interrogated so harshly that their bodies gave up, a singular moon mote flies above the elf selunes prescence is not lost even here", false);
            Room MyrkulsAltar = new Room("this dry, partially collapsed room contains a stone altar with humanoid skulls and bones piled around it. the top of the altar is covered with dozens of half-melted candlesmade of black wax, all currently unlit, this room shows clear signs of belonging to the lord of bones, Myrkul", false);
            Room NotTheEnd = new Room("this room is flooded like all the rest with water knee deep, though on the floor is a fist of bane lying dead with a laceration deep piercing even the gambeson", true);
            Room TemporaryRespite = new Room("as you enter this room, you see the supports struck with cuts and slashes, even an arrow sticking off one beam as you hear footsteps wading through water up ahead", false);
            Room BattleRoom= new Room("as you enter this room, you see the dead body of a tall massive man, great club in hand, as you recognise him as mortlock vanthampur, son of Thalamra, over him stands a 'death's head of bhaal' seeming to be the only one left after the brawl with mortlock, 4 other death heads lay on the ground battered and dead", false);
            Room StolenTreasureRoom = new Room("this room contains a whole hoard of treasure, smelling of sulfure and of dragons, it can be deduced this came from Tiamat, lord of evil dragons, this must be how the cult of the dead three finance their crimes", false);
            
            RoomList.Add(DungeonEntrance);
            RoomList.Add(HexagonalRoom);
            RoomList.Add(BanesRoom);
            RoomList.Add(BhaalsAltar);
            RoomList.Add(BanesPrison);
            RoomList.Add(MyrkulsAltar);
            RoomList.Add(NotTheEnd);
            RoomList.Add(TemporaryRespite);
            RoomList.Add(BattleRoom);
            RoomList.Add(StolenTreasureRoom);
        }

        public void Start()
        {
            bool playing = true;
            CurrentRoom = 0;
            LootList.Add("an odd shaped key");
            LootList.Add("a slightly rusted sword");
            LootList.Add("");
            LootList.Add("");
            LootList.Add("a potion of healing");
            LootList.Add("");
            LootList.Add("kowledge to pull the torch");
            LootList.Add("");
            LootList.Add("");
            LootList.Add("a mountain of gold, stolen by the dead three from tiamat");

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
                        Console.WriteLine(RoomList[CurrentRoom].GetDescription());
                        if (PlayerInventory.Contains(LootList[CurrentRoom]) == false)
                        {
                            Console.WriteLine("further, you find " + LootList[CurrentRoom]);
                            RoomList[CurrentRoom].SetIsLocked(false);
                            Player1.PickUpItem(LootList[CurrentRoom]);
                        }
                    }
                    if (KeyInput == "m")
                    {
                        Console.Clear();
                        Console.Write("how do you wish to move, u = up, d = down");
                        KeyInput = Console.ReadLine();
                        if (KeyInput == "u" && CurrentRoom != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("you traverse along the corredors and enter a new room.");
                            CurrentRoom = CurrentRoom - 1;
                        }
                        else if (KeyInput == "d" && RoomList[CurrentRoom].GetIsLocked() == true)
                        {
                            Console.WriteLine("as you attempt to go forwards, you are stopped in your tracks, maybe search the room for something useful");
                        }
                        else if (KeyInput == "d" && CurrentRoom != 9)
                        {
                            Console.Clear();
                            Console.WriteLine("you traverse along the corredors and enter a new room.");
                            CurrentRoom = CurrentRoom + 1;
                        }
                        else if ((KeyInput == "u" && CurrentRoom == 0) || (KeyInput == "d" && CurrentRoom == 9))
                        {
                            Console.WriteLine("you are already at an end of the dungeon, try again");
                        }
                        else
                        {
                            Console.WriteLine("please enter either 'u' or 'd' when moving.");
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