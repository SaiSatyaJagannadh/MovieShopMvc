using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMvc.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        // GET: MovieController
        public ActionResult Index()
        {
            return View();
        }
        
        //for details method
        public ActionResult MovieDetails(int id)
        {
            var movie = _movieService.GetMovieDetails(id);
            return View(movie);
        }
    
        [HttpPost]
        public ActionResult DeleteMovie(int id)
        {
            var m=_movieService.DeleteMovie(id);
            if (m == null)
            {
                return NotFound();
            }
            else
            {
                _movieService.DeleteMovie(id);

            }
            //return View("Index");
            return RedirectToAction("Index", "Home");
        }

        // [HttpGet]
        // public ActionResult Details(int id)
        // {
        //     // call the Movie service that will call Movie Repository
        //     var movieDetails = _movieService.GetMovieById(id);
        //     return View(movieDetails);
        // }
        
        public async Task<ActionResult> Details(int id)
        {
            var movieDetails = await _movieService.GetMovieById(id); // ✅ now it's MovieDetailsModel
            return View(movieDetails);
        }
        
    }
}
