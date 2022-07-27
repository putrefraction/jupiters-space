using JupitersSpace.Shared; /* Posts */

namespace JupitersSpace.Mvc.Models;

public record PostsIndexViewModel
(
    IList<Post> Posts
);