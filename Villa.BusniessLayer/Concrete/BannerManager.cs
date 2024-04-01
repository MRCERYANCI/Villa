using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.BusniessLayer.Abstract;
using Villa.DataAccessLayer.Abstract;
using Villa.EntityLayer.Entities;

namespace Villa.BusniessLayer.Concrete
{
    public class BannerManager : GenericServiceManager<Banner> , IBannerService
    {
        public BannerManager(IGenericDal<Banner> genericDal) : base(genericDal)
        {
            
        }
    }
}
