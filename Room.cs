namespace DungeonExplorer
{
    public class Room
    {
        private string Description;
        private bool IsLocked;
        private int EnemiesInRoom;


        public Room(string description, bool islocked, int enemiesInRoom)
        {
            Description = description;
            IsLocked = islocked;
            EnemiesInRoom = enemiesInRoom;
        }
        public string GetDescription()
        {
            return Description;
        }
        public bool GetIsLocked()
        {
            return IsLocked;
        }
        public int GetEnemiesInRoom()
        {
            return EnemiesInRoom;
        }
        public void SetIsLocked(bool value)
        {
            IsLocked = value;
        }
        public void SetEnemiesInRoom(int value)
        {
            EnemiesInRoom = value;
        }

    }
}