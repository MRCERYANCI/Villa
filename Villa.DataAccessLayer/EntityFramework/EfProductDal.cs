﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.DataAccessLayer.Abstract;
using Villa.DataAccessLayer.Context;
using Villa.DataAccessLayer.Repositories;
using Villa.EntityLayer.Entities;

namespace Villa.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product> , IProductDal
    {
        public EfProductDal(VillaContext villaContext) : base(villaContext)
        {
            
        }
    }
}
