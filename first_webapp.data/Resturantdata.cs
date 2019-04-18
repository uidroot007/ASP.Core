using System;
using System.Collections.Generic;
using first_webapp_resturants;
using System.Linq;

namespace first_webapp.data
{
    public interface IResturantdata
    {
        IEnumerable<Resturant> GetResturantsByName(string name);
        Resturant GetById(int Id);
    }
    public class InMemoryResturantData : IResturantdata
    {
        readonly List<Resturant> resturants;
        public InMemoryResturantData()
        {
            resturants = new List<Resturant>()
            { 
              new Resturant { Name = "Amjees", Location = "Odense", Id =1, Cusinie=CusinieType.Indian },
              new Resturant { Name = "Mama pizza", Location = "Roskilde", Id =2, Cusinie=CusinieType.American }
            };
        }

        public Resturant GetById(int Id)
        {
            return resturants.SingleOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Resturant> GetResturantsByName(string name = null) {
            return from r in resturants
                    where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, StringComparison.Ordinal)
                   orderby r.Name select r;
        }
    }
}
