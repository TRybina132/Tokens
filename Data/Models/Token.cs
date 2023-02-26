namespace Data.Models;

public class Token : BaseModel
{
    public string Value { get; set; }

    public string Name { get; set; }

    public string Notes { get; set; }

    public string Tags { get; set; }

    public DateTime CreationDate { get; set; }
}