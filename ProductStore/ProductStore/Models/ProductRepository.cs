using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Tweets> products = new List<Tweets>();
       TweetsDBContext db = new TweetsDBContext();
        private int _nextId = 1;

        public ProductRepository()
        {
           
       
        //Add(new Tweets { Id = 1, Name =  "realDonaldTrump" , Date = "2016-06-19", Text = "Ted Cruz lifts the Bible high into the air and then lies like a dog-over and over again! The Evangelicals in S.C. figured him out &amp; said no!" });
        //Add(new Tweets { Id = 2, Name =  "realDonaldTrump" , Date = "2016-06-20", Text = "Ted Cruz does not have the right temperment to be President. Look at the way he totally panicked in firing his director of comm. BAD!" });
        //Add(new Tweets { Id = 3, Name =  "realDonaldTrump" , Date = "2016-06-21", Text = "Wow was Ted Cruz disloyal to his very capable director of communication. He used him as a scape goat-fired like a dog! Ted panicked." });
        //Add(new Tweets { Id = 4, Name =  "realDonaldTrump" , Date = "2016-06-21", Text = "Ted Cruz only talks tough on immigration now because he did so badly in S.C. He is in favor of amnesty and weak on illegal immigration." });
        
        foreach(Tweets prod in products)
            {
               //db.Products.Add(prod);

            }
           
        }

        public IEnumerable<Tweets> GetAll()
        {
            //return products;
            return db.Products;
        }

        public Tweets Get(int id)
        {
            // return products.Find(p => p.Id == id);
            return db.Products.Find(id);
        }

        public Tweets Add(Tweets item)
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
            Tweets t = db.Products.Find(id);
            db.Products.Remove(t);
            db.SaveChanges();
        }

        public bool Update(Tweets item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            //int index = products.FindIndex(p => p.Id == item.Id);
            //if (index == -1)
            //{
            //    return false;
            //}
            
            //products.RemoveAt(index);
            //products.Add(item);
            Tweets toRemove = db.Products.Find(item.Id);
            db.Products.Remove(toRemove);
            db.Products.Add(item);
            db.SaveChanges();
            return true;
        }
    }
}