namespace Model
{
    public abstract class Player : DataObject
    {
        public int Price { get; set; }
        public int MaxPerTeam { get; protected set; }

        protected static int GoalkeepersMaxPerTeam => 3;
        protected static int DefendersMaxPerTeam => 8;
        protected static int MidfieldersMaxPerTeam => 8;
        protected static int ForwardsMaxPerTeam => 6;

        public virtual Team? Team { get; set; }
    }
}
