using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();
        ProductDBContext db = new ProductDBContext();
        private int _nextId = 1;

        public ProductRepository()
        {
           
        Add(new Product { Name =  "@realDonaldTrump" , Category =  "2/22/2016" , Price = "I am growing the Republican Party tremendously - just look at the numbers, way up! Democrats numbers are significantly down from years past." });

        Add(new Product { Name =  "@realDonaldTrump" , Category =  "6/2/2016" , Price = "Ted Cruz lifts the Bible high into the air and then lies like a dog-over and over again! The Evangelicals in S.C. figured him out &amp; said no!" });
        Add(new Product { Name =  "@realDonaldTrump" , Category =  "7/20/2017" , Price = "Ted Cruz does not have the right temperment to be President. Look at the way he totally panicked in firing his director of comm. BAD!" });
        Add(new Product { Name =  "@realDonaldTrump" , Category =  "5/18/2017" , Price = "Wow was Ted Cruz disloyal to his very capable director of communication. He used him as a scape goat-fired like a dog! Ted panicked." });
        Add(new Product { Name =  "@realDonaldTrump" , Category =  "12/11/2016" , Price = "Ted Cruz only talks tough on immigration now because he did so badly in S.C. He is in favor of amnesty and weak on illegal immigration." });
        
        foreach(Product prod in products)
            {
                db.Products.Add(prod);

            }
           
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.Local.ToList();
        }

        public Product Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            products.Add(item);
            db.Products.Add(item);
            db.SaveChanges();
            return item;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}