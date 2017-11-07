using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    public class Tweets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }

        
    }
    public class TweetsDBContext : DbContext
    {
        public DbSet<Tweets> Products { get; set; }
    }
}