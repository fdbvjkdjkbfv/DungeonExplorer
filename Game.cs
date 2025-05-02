using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        public List<Room> RoomList = new List<Room>();
        public List<string> LootList = new List<string>();
        public List<Monster> MonsterList = new List<Monster>();

        private int CurrentRoom;
        private int CurrentMonster;
        private Player Player1;
        string KeyInput;
        bool InGame = false;
        int AttackRoll;
        int EnemyAttackRoll;

        public Game()
        {
            Testing testing = new Testing();
            Player1 = new Player(testing.SetName(), 24, 5, 17, "you fall to the ground, losing strength each second, you were unable to stop the cult and will soon be decided on by Kelemvor in the city of judgement"); //+3 to hit
            Room DungeonEntrance = new Room("as you examine this room you find that its flooded to a distance of a foot high with grime all over the walls and ferrous sort of smell, at the end of the room is a door made of rotten looking wood planks, while decrepid it seems to still have a lock on it", true, 0);
            Room HexagonalRoom = new Room("you enter a hexagonal room, almost empty but not bereft of decor, for on the door to the east is a face bearing  a tall armoured man wearing a bucket helm, his right gauntlet painted black and clutching a set of shackles, you recognise this image as the visage of Bane, the god of tyranny", false, 0);
            Room BanesRoom = new Room("as you enter this room you notice the far eastern part is unlit with the floor flooded and the walls braced, a man wielding a mace, wearing a bucket helm and wading in the murky water turns his gaze from a corpse, just recently killed, to meet your gaze", false, 1);
            Room BhaalsAltar = new Room("in the room there are 3 wooden beams from floor to cieling, a stone altar at the north of the room laiden with blood spilt from an offering days ago, above that altar is hanging  three foot tall steel mask, laiden with red gem bejewelled tears, and you see this bears likeness to bhaal the lord of murder", false, 0);
            Room BanesPrison = new Room("in this room, the walls and floor engulfed by spattering of blood, on the floor are the bodies of a wood elf and a tiefling, both seemed to be interrogated so harshly that their bodies gave up, a singular moon mote flies above the elf selunes prescence is not lost even here", false, 0);
            Room MyrkulsAltar = new Room("this dry, partially collapsed room contains a stone altar with humanoid skulls and bones piled around it. the top of the altar is covered with dozens of half-melted candlesmade of black wax, all currently unlit, this room shows clear signs of belonging to the lord of bones, Myrkul", false, 0);
            Room NotTheEnd = new Room("this room is flooded like all the rest with water knee deep, though on the floor is a fist of bane lying dead with a laceration deep piercing even the gambeson", true, 0);
            Room TemporaryRespite = new Room("as you enter this room, you see the supports struck with cuts and slashes, even an arrow sticking off one beam as you hear footsteps wading through water up ahead", false, 0);
            Room BattleRoom= new Room("as you enter this room, you see the dead body of a tall massive man, great club in hand, as you recognise him as mortlock vanthampur, son of Thalamra, over him stands a 'death's head of bhaal' seeming to be the only one left after the brawl with mortlock, 4 other death heads lay on the ground battered and dead", false, 1);
            Room StolenTreasureRoom = new Room("this room contains a whole hoard of treasure, smelling of sulfure and of dragons, it can be deduced this came from Tiamat, lord of evil dragons, this must be how the cult of the dead three finance their crimes", false, 0);
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

            Monster IronConsul = new Monster("Yignath", 20, 4, 16, 4, "As the Iron consul falls, bane is again deprived of a servant");
            Monster DeathsHead = new Monster("Vaaz", 42, 6, 15, 5, "As the Death's head falls, bhaal is not saddened, as more blood is given to him through murder");
            MonsterList.Add(IronConsul);
            MonsterList.Add(DeathsHead);
        }

        public void Start()
        {
            Random rnd = new Random();
            bool playing = true;
            CurrentRoom = 0;
            CurrentMonster = 0;
            LootList.Add("an odd shaped key");
            LootList.Add("a rusted broken sword");
            LootList.Add("");
            LootList.Add("");
            LootList.Add("Letter to Mortlock Vanthampur, enticing him to help out his mother");
            LootList.Add("");
            LootList.Add("kowledge to pull the torch");
            LootList.Add("");
            LootList.Add("");
            LootList.Add("a mountain of gold, stolen by the dead three from tiamat");

            while (playing)
            {
                Console.WriteLine("beware, as this is the dungeon of the dead three (bane, bhaal and myrkul) this will contain some descriptions of gore");
                if (InGame == false)
                {
                    Console.WriteLine("what do you wish to do: q = quit, e = enter game: ");
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
                    if (RoomList[CurrentRoom].GetEnemiesInRoom() == 1)
                    {
                        if (CurrentRoom == 2)
                        {
                            CurrentMonster = 0;
                        }
                        else
                        {
                            CurrentMonster = 1;
                        }
                        while (RoomList[CurrentRoom].GetEnemiesInRoom() == 1 && Player1.GetHealth() > 0)
                        {
                            Console.WriteLine("------------------------------------------------------------");
                            Console.WriteLine($"{Player1.GetName()}: health = {Player1.GetHealth()}");
                            Console.WriteLine($"{MonsterList[CurrentMonster].GetName()}: health = {MonsterList[CurrentMonster].GetHealth()}");
                            Console.WriteLine("what do you wish to do: a = attack, f = flee (beware, this will invoke an opportunity attack)");
                            KeyInput = Console.ReadLine();
                            if (KeyInput == "a")
                            {
                                AttackRoll = 4 + rnd.Next(1, 21);
                                if (AttackRoll > MonsterList[CurrentMonster].GetAC())
                                {
                                    MonsterList[CurrentMonster].SetHealth(MonsterList[CurrentMonster].GetHealth() - Player1.GetDamage());
                                    Console.WriteLine($"with an attack of {AttackRoll}, you dealt {Player1.GetDamage()} points of damage to {MonsterList[CurrentMonster].GetName()}");
                                }
                                else
                                {
                                    Console.WriteLine($"with an attack of {AttackRoll}, you miss {MonsterList[CurrentMonster].GetName()}");
                                }
                                if (MonsterList[CurrentMonster].GetHealth() <= 0)
                                {
                                    Console.WriteLine(MonsterList[CurrentMonster].SayDeathMessage());
                                    Console.WriteLine($"and with that, {MonsterList[CurrentMonster].GetName()} falls to the floor and this room is cleared");
                                    RoomList[CurrentRoom].SetEnemiesInRoom(0);
                                }
                                if (MonsterList[CurrentMonster].GetHealth() > 0)
                                {
                                    EnemyAttackRoll = MonsterList[CurrentMonster].GetAttackBonus() + rnd.Next(1, 21);
                                    if (EnemyAttackRoll > Player1.GetAC())
                                    {
                                        Player1.SetHealth(Player1.GetHealth() - MonsterList[CurrentMonster].GetDamage());
                                        Console.WriteLine($"with an attack of {EnemyAttackRoll}, {MonsterList[CurrentMonster].GetName()} dealt {MonsterList[CurrentMonster].GetDamage()} points of damage to you");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"with an attack of {EnemyAttackRoll}, {MonsterList[CurrentMonster].GetName()} did not hit you");
                                    }
                                }
                            }
                            if (KeyInput == "f")
                            {
                                EnemyAttackRoll = MonsterList[CurrentMonster].GetAttackBonus() + rnd.Next(1, 21);
                                if (EnemyAttackRoll > Player1.GetAC())
                                {
                                    Player1.SetHealth(Player1.GetHealth() - MonsterList[CurrentMonster].GetDamage());
                                    Console.WriteLine($"as you retreat, you are dealt with {MonsterList[CurrentMonster].GetDamage()} points of damage");
                                }
                                else
                                {
                                    Console.WriteLine("as you retreat you successfully manage to avoid any damage to you");
                                }
                                CurrentRoom = CurrentRoom - 1;
                            }
                            if (Player1.GetHealth() <= 0)
                            {
                                Console.WriteLine(Player1.SayDeathMessage());
                                Console.WriteLine($"and with that {Player1.GetName()} lies cold on the floors in the dungeons, their blood seeping into the stone");
                                playing = false;
                                InGame = false;
                            }
                        }
                    }
                    if (Player1.GetHealth() <= 0)
                    {
                        continue;
                    }
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
                        else
                        {
                            Console.WriteLine("upon looking, there is nothing more of note is found");
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
                            Console.WriteLine("you traverse along the corridors and enter a new room.");
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
