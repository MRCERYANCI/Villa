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
    public class ContactManager : GenericServiceManager<Contact> ,  IContactService
    {
        public ContactManager(IGenericDal<Contact> genericDal) : base(genericDal)
        {
            
        }
    }
}
