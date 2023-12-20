namespace efejemplo.Models;

public class Task 
{
    public Guid Id { get; set; }

    public Guid CategoryId { get; set; }

    public string Title { get; set; }

    public string ?Description { get; set; }

    public Properties TaskProperty { get; set; }

    public DateTime DateCreation { get; set; }

    public virtual Category Category { get; set; }

}

public enum Properties {
    LOW,
    MEDIUM,
    HIGH
}