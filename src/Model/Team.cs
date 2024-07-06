namespace Model
{
    public class Team : DataObject
    {
        public string? League { get; set; }

        public virtual ICollection<Goalkeeper> Goalkeepers { get; set; } = new List<Goalkeeper>();
        public virtual ICollection<Defender> Defenders { get; set; } = new List<Defender>();
        public virtual ICollection<Midfielder> Midfielders { get; set; } = new List<Midfielder>();
        public virtual ICollection<Forward> Forwards { get; set; } = new List<Forward>();
    }
}
