using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Models
{
    public interface IProductRepository
    {
        IEnumerable<Tweets> GetAll();
        Tweets Get(int id);
        Tweets Add(Tweets item);
        void Remove(int id);
        bool Update(Tweets item);
    }
}
