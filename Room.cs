namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private bool IsLocked;


        public Room(string description, bool islocked)
        {
            this.description = description;
            this.IsLocked = islocked;
        }

        public string GetDescription()
        {
            return description;
        }

        public bool GetIsLocked()
        {
            return IsLocked;
        }
        public void SetIsLocked(bool value)
        {
            IsLocked = value;
        }
    }
}