using System.Diagnostics;
using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMvc.Models;

namespace MovieShopMvc.Controllers;

public class HomeController : Controller
{
    
    //Depedency Injection 
    //ImovieService is a Movieservice interface 
    private readonly IMovieService _movieService;
    
    //by creating Constructor 
    public HomeController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    //for TopMovies
    [HttpGet]
    public IActionResult TopMovies()
    {
        //every IActionable returns view
        //logic: go to the db and get the some movie list<Movie>
        //var m=movieService.GetTopMovies() return view(m);
        return View();
    }
    
    //http//movies.com/home/topgrosseingmovies
    //home in above is here controller//for topgross we need to
    //Create the method
    //for topgrosseingmovies method
    [HttpGet]
    public IActionResult TopGrossingMovies()
    {
        return View();
    }
    public IActionResult Index()
    {
        //most of the logic come from other services
        //movieservice
        
        //MovieService ms= new MovieService();
        //var movies=movieService.GetTop20Movies()
        //void Method(int x, ImovieService service);
        //class MovieService:IMoviService
        //MovieService ms=new MovieService();
        //method(20,ms); // like this we call service

        ViewData["Age"] = 30;
        ViewData["Title"] = "Movies Images";
        ViewBag.Age = 30;
        ViewBag.Title = "Movies Images";
        
        //implement or creating instance for everytime is not need 
        //var m = new MovieService();
        //to not create a instance we can do this 

        var movies = _movieService.TopGrossingMovies();
        //var movies = _movieService.TopGrossingMovies();
        //var m=_movieService.TopGrossingMovies()
        return View(movies);

    }
    
    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}