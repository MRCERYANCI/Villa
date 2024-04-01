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
    public class QuestManager : GenericServiceManager<Quest>, IQuestService
    {
        public QuestManager(IGenericDal<Quest> genericDal) : base(genericDal)
        {
            
        }
    }
}
