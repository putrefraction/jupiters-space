using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JupitersSpace.Mvc.Models;
using JupitersSpace.Shared;

namespace JupitersSpace.Mvc;

public class PostsController : Controller
{
    private readonly JupitersContext db;

    public PostsController(JupitersContext injectedContext)
    {
        this.db = injectedContext;
    }

    public async Task<IActionResult> Index()
    {

        PostsIndexViewModel model = new(
            Posts: await db.Posts.ToListAsync()
        );
        return View(model);
    }


}