using System;
using System.Collections.Generic;
using first_webapp_resturants;
using System.Linq;

namespace first_webapp.data
{
    public interface IResturantdata
    {
        IEnumerable<Resturant> GetResturants();
    }
    public class InMemoryResturantData : IResturantdata
    {
        readonly List<Resturant> resturants;
        public InMemoryResturantData()
        {
            resturants = new List<Resturant>()
            { 
              new Resturant { Name = "Amjees", Location = "Odense", Id =1, Cusinie=CusinieType.Indian },
              new Resturant { Name = "Mama pizza", Location = "Roskilde", Id =1, Cusinie=CusinieType.American }
            };
        }
        IEnumerable<Resturant> IResturantdata.GetResturants() => from r in resturants orderby r.Name select r;
    }
}
