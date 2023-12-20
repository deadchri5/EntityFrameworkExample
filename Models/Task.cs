using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efejemplo.Models;

public class Task 
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    public string ?Description { get; set; }

    public Properties TaskProperty { get; set; }

    public DateTime DateCreation { get; set; }

    public virtual Category Category { get; set; }

    [NotMapped]
    public string Resumen { get; set; }

}

public enum Properties {
    LOW,
    MEDIUM,
    HIGH
}