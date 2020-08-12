using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiku.Models;

namespace webapiku.Models
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        public DbSet<WebItem> WebItems { get; set; }

        public DbSet<webapiku.Models.TodoItemDTO> TodoItemDTO { get; set; }
    }
}
