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
    public class VideoManager : GenericServiceManager<Video> , IVideoService
    {
        public VideoManager(IGenericDal<Video> genericDal) : base(genericDal)
        {
            
        }
    }
}
