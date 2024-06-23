namespace Model
{
    public class Team
    {
        public string? Name { get; set; }

        public List<Goalkeeper> Goalkeepers { get; } = [];
        public List<Defender> Defenders { get; } = [];
        public List<Midfielder> Midfielders { get; } = [];
        public List<Forward> Forwards { get; } = [];

        private static bool Add<T>(List<T> list, T player) where T : Player
        {
            if(list.Count >= player.MaxPerTeam)
            {
                return false;
            }

            list.Add(player);
            return true;
        }

        public bool AddGoalkeeper(Goalkeeper player) => Add(Goalkeepers, player);
        public bool AddDefender(Defender player) => Add(Defenders, player);
        public bool AddMidfielder(Midfielder player) => Add(Midfielders, player);
        public bool AddForward(Forward player) => Add(Forwards, player);

    }
}
