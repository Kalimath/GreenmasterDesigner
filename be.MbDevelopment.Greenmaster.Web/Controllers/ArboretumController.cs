using Microsoft.AspNetCore.Mvc;

namespace be.MbDevelopment.Greenmaster.Web.Controllers;

public class ArboretumController : Controller
{
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
}