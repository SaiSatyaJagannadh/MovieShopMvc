using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMvc.ViewComponents;

public class GenresViewComponent : ViewComponent
{
    private readonly IGenreService _genreService;

    public GenresViewComponent(IGenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var genres = await _genreService.GetAllGenres();
        // by conention it will look for a view name Default.cshtml
        return View(genres);
    }


}