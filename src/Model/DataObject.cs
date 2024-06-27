using SQLite;

namespace Model
{
    public abstract class DataObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
