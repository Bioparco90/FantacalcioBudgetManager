using SQLite;

namespace Model
{
    public class Player : DataObject
    {
        public int Price { get; set; }
        public Role Role { get; set; }

        [Indexed]
        public Guid TeamId { get; set; }

        [Ignore]
        public int MaxPerTeam =>
        Role switch
        {
            Role.Goalkeeper => GoalkeepersMaxPerTeam,
            Role.Defender => DefendersMaxPerTeam,
            Role.Midfielder => MidfieldersMaxPerTeam,
            Role.Forward => ForwardsMaxPerTeam,
            _ => 0,
        };

        [Ignore]
        private static int GoalkeepersMaxPerTeam => 3;

        [Ignore]
        private static int DefendersMaxPerTeam => 8;

        [Ignore]
        private static int MidfieldersMaxPerTeam => 8;

        [Ignore]
        private static int ForwardsMaxPerTeam => 6;
    }
}
