using DataAccess;
using Model;

namespace Logic
{
    public class Logics(Context dbContext)
    {
        private readonly Context _dbContext = dbContext;

        public void CreateTeam(Team team)
        {
            _dbContext.Teams.Add(team);
            SaveChanges();
        }
        public void AddGoalkeeper(Team team, Goalkeeper player) => _dbContext.Teams.Find(team.Id)?.Goalkeepers.Add(player);
        //public bool AddDefender(Defender player) => Add(team.Defenders, player);
        //public bool AddMidfielder(Midfielder player) => Add(team.Midfielders, player);
        //public bool AddForward(Forward player) => Add(team.Forwards, player);

        public void SaveChanges() => _dbContext.SaveChanges();
    }
}
