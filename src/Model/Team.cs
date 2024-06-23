namespace Model
{
    public class Team
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Goalkeeper>? Goalkeepers { get; }
        public virtual ICollection<Defender>? Defenders { get; }
        public virtual ICollection<Midfielder>? Midfielders { get; }
        public virtual ICollection<Forward>? Forwards { get; }
    }
}
