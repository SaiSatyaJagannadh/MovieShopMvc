using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Review
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public decimal Rating { get; set; }
    public string ReviewText { get; set; }
    public virtual User User { get; set; }
    public Movie Movie { get; set; }
}