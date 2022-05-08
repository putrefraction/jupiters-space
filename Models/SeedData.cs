using Microsoft.EntityFrameworkCore;


namespace jupiters_space.Models {

    // This populates the database with dummy posts for testing
    public static class SeedData {
        public static void Initialize(IServiceProvider serviceProvider){
            using (var context = new PostsContext(
                serviceProvider.GetRequiredService<DbContextOptions<PostsContext>>()))
            {

                // if there are any posts, then the db is already populated
                if (context.Post.Any()){
                    return;
                }

                context.Post.AddRange(
                    new Post
                    {
                        Title = "A look into the intraspace subharmonics",
                        Subtitle = "Or: How I found myself, and how I keep myself from realizing it.",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non ex laoreet, accumsan nisi ac, cursus libero. Sed nec viverra orci. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam consequat vestibulum turpis, quis iaculis neque laoreet euismod. Aliquam ullamcorper nulla nec est tristique posuere. Quisque molestie mattis metus ac sodales. Etiam consectetur nulla ac metus rutrum tempor. Aenean lobortis auctor semper. Donec sed neque nec purus ultrices laoreet nec eget est. Donec vestibulum mauris at ex iaculis, at feugiat nunc ornare. Nullam tempus justo varius arcu tristique, et efficitur sapien eleifend. Fusce bibendum et diam vitae dignissim. "
                    },
                    new Post
                    {
                        Title = "A look into the intraspace subharmonics",
                        Subtitle = "Or: How I found myself, and how I keep myself from realizing it.",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non ex laoreet, accumsan nisi ac, cursus libero. Sed nec viverra orci. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam consequat vestibulum turpis, quis iaculis neque laoreet euismod. Aliquam ullamcorper nulla nec est tristique posuere. Quisque molestie mattis metus ac sodales. Etiam consectetur nulla ac metus rutrum tempor. Aenean lobortis auctor semper. Donec sed neque nec purus ultrices laoreet nec eget est. Donec vestibulum mauris at ex iaculis, at feugiat nunc ornare. Nullam tempus justo varius arcu tristique, et efficitur sapien eleifend. Fusce bibendum et diam vitae dignissim. "
                    },
                    new Post
                    {
                        Title = "A look into the intraspace subharmonics",
                        Subtitle = "Or: How I found myself, and how I keep myself from realizing it.",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non ex laoreet, accumsan nisi ac, cursus libero. Sed nec viverra orci. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam consequat vestibulum turpis, quis iaculis neque laoreet euismod. Aliquam ullamcorper nulla nec est tristique posuere. Quisque molestie mattis metus ac sodales. Etiam consectetur nulla ac metus rutrum tempor. Aenean lobortis auctor semper. Donec sed neque nec purus ultrices laoreet nec eget est. Donec vestibulum mauris at ex iaculis, at feugiat nunc ornare. Nullam tempus justo varius arcu tristique, et efficitur sapien eleifend. Fusce bibendum et diam vitae dignissim. "
                    },
                    new Post
                    {
                        Title = "A look into the intraspace subharmonics",
                        Subtitle = "Or: How I found myself, and how I keep myself from realizing it.",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non ex laoreet, accumsan nisi ac, cursus libero. Sed nec viverra orci. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam consequat vestibulum turpis, quis iaculis neque laoreet euismod. Aliquam ullamcorper nulla nec est tristique posuere. Quisque molestie mattis metus ac sodales. Etiam consectetur nulla ac metus rutrum tempor. Aenean lobortis auctor semper. Donec sed neque nec purus ultrices laoreet nec eget est. Donec vestibulum mauris at ex iaculis, at feugiat nunc ornare. Nullam tempus justo varius arcu tristique, et efficitur sapien eleifend. Fusce bibendum et diam vitae dignissim. "
                    }
                );
                context.SaveChanges();


            }
        }
    }
}