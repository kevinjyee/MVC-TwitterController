using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductStore.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;

namespace ProductStore.Controllers
{

    public class ProductsController : ApiController
    {

        

        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable<Tweets> GetAllProducts()
        {
            return repository.GetAll();

        }

        public Tweets GetProduct(int id)
        {
            Tweets item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Tweets> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Date, category, StringComparison.OrdinalIgnoreCase));
        }

        public Tweets PostProduct(Tweets item)
        {
            item = repository.Add(item);
            return item;
        }

        public void PutProduct(Tweets product)
        {
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProduct(int id)
        {
            Tweets item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }
}
