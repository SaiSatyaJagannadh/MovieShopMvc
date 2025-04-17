using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMvc.Controllers;

public class AccountController: Controller
{
    
    //we done this for http//moviesdb.com/account/register
    //fpr account we created controller and for register method inside the controller
    //for index and register we need to create the view 
    public ActionResult Login()
    {
        return View();
    }

    public ActionResult Register(RegisterViewModel model)
    {
        return View(model);
    }

    // public ActionResult Register(int id, string name)
    // {
    //     return View();
    // }
    
}