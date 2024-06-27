namespace Model
{
    public class Team : DataObject
    {
        public virtual ICollection<Goalkeeper>? Goalkeepers { get; }
        public virtual ICollection<Defender>? Defenders { get; }
        public virtual ICollection<Midfielder>? Midfielders { get; }
        public virtual ICollection<Forward>? Forwards { get; }
    }
}
