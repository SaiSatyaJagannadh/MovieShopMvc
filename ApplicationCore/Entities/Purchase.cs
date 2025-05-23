using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Purchase
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Guid PurchaseNumber { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime PurchaseDateTime { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public User Customer { get; set; }
}