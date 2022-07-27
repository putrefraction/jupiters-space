using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommonMark;
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
            Posts: await db.Posts.OrderByDescending(p => p.PostId).ToListAsync()
        );
        return View(model);
    }

    public async Task<IActionResult> Post(string? slug)
    {
        if (slug != null)
        {
            Post? post = await db.Posts.SingleOrDefaultAsync(p => p.Slug == slug);

            if (post == null)
            {
                return NotFound();
            }
            else 
            {
                string path = Path.Join("/home/faura/Documents/Code/jupiters-space/JupitersSpace.Mvc/Files/", post.Content);

                string postContent = System.IO.File.ReadAllText(path);
                string postHtml = CommonMark.CommonMarkConverter.Convert(postContent);


                PostViewModel model = new(
                    Title: post.Title,
                    Subtitle: post.Subtitle,
                    PostText: postHtml
                );
                return View(model);
            }
        }
        else {
            return View();
        }
    }
}