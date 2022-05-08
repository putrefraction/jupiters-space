#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using jupiters_space.Models;

    public class PostsContext : DbContext 
    {
        public PostsContext (DbContextOptions<PostsContext> options)
            : base(options)
        {
        }

        public DbSet<jupiters_space.Models.Post> Post { get; set; }
    }
