namespace Model
{
    public abstract class DataObject
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
