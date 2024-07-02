namespace Model
{
    public class Team : DataObject
    {
        public string? League { get; set; }

        public virtual ICollection<Goalkeeper>? Goalkeepers { get; set; } = [];
        public virtual ICollection<Defender>? Defenders { get; set; } = [];
        public virtual ICollection<Midfielder>? Midfielders { get; set; } = [];
        public virtual ICollection<Forward>? Forwards { get; set; } = [];
    }
}
