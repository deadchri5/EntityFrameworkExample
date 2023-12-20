using System.ComponentModel.DataAnnotations;

namespace efejemplo.Models;

public class Category
{
    [Key]
    public Guid CategoryId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(150)]
    public string ?Name { get; set; }

    public string ?Description { get; set; }

    public virtual ICollection<Task> Tasks { get; set; }

}