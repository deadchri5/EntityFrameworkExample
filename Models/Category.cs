namespace efejemplo.Models;

public class Category
{
    public Guid Id { get; set; }

    public string ?Name { get; set; }

    public string ?Description { get; set; }

    public virtual ICollection<Task> Tasks { get; set; }

}