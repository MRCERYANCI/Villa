using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.BusniessLayer.Abstract;
using Villa.DataAccessLayer.Abstract;
using Villa.EntityLayer.Entities;

namespace Villa.BusniessLayer.Concrete
{
    public class FeatureManager : GenericServiceManager<Feature> , IFeatureService
    {
        public FeatureManager(IGenericDal<Feature> genericDal) : base(genericDal)
        {
            
        }
    }
}
