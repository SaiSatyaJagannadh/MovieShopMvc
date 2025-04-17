using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Trailer
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public string TrailerUrl { get; set; }
    public string Name { get; set; }
        
    //Navigation property: a trailer belongs to one movie
    public Movie Movie { get; set; }
}