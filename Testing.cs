using System;
namespace DungeonExplorer
{
    public class Testing
    {
        bool SuitableName = false;
        bool TriedChangedLater = false;
        string EnteredName = "";
        public string SetName()
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
            return EnteredName;
        }
    }
}