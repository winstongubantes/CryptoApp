using SQLite;

namespace CryptoApp.Models.Entities.Base
{
    public interface IEntityRecord
    {
        int LocalId { get; set; }
    }

    public class EntityRecord : IEntityRecord
    {
        [PrimaryKey, AutoIncrement]
        public int LocalId { get; set; }
    }
}
