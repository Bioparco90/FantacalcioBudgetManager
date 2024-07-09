namespace Model
{
    public class Team : DataObject
    {
        public string? League { get; set; }

        public virtual ICollection<Player> Players { get; set; } = [];
    }
}
