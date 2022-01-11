﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRepo
{
    public interface IStoreAdminRepo
    {
        public Task<int> SignUpAdmin(StoreSignUpDTO storeSignUpDTO);
    }
}
