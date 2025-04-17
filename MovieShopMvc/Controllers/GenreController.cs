using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMvc.Controllers;

public class GenreController : Controller
{
    
    
    private readonly IGenreService _genreService;
    private readonly IMovieService _movieService;


    public GenreController(IGenreService genreService, IMovieService movieService)
    {
        _genreService = genreService;
        _movieService = movieService;
    }
    
    // [HttpGet]
    // public IActionResult GenreBy()
    // {
    //     var m=_genreService.GetAllGenres();
    //     return View(m);
    // }
    
    
    [HttpGet]
    public async Task<IActionResult> GenreBy(int id)
    {
        var movies = await _movieService.GetMoviesByGenre(id); // <-- implement this
        return View(movies);
    }

}