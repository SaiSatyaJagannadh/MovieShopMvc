using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

// ✅ Genre
[Table(name:"Genre")]
public class Genre
{
    public int Id { get; set; }
    [MaxLength(24)]
    public string Name { get; set; }

    //Navigation property
    public ICollection<Movie> Movies { get; set; }
}
