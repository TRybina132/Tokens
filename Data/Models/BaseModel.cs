using SQLite;

namespace Data.Models;

public class BaseModel
{
    [PrimaryKey, AutoIncrement, Column("Id")]
    public string Id { get; set; }
}