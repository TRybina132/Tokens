using SQLite;

namespace Data.Models;

[Table("Tokens")]
public class Token : BaseModel
{
    public string Value { get; set; }

    [MaxLength(250), Unique]

    public string Name { get; set; }

    public string Notes { get; set; }

    public string Tags { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.Now;
}