using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace efejemplo.Models;

public class Category
{
    // [Key]
    public Guid CategoryId { get; set; }

    // [Required(ErrorMessage = "Name is required")]
    // [MaxLength(150)]
    public string ?Name { get; set; }

    public int Effort { get; set; }

    public string ?Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; }

}