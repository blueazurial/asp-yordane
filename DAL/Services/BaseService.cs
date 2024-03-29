﻿using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public abstract class BaseService<T>
    {
        protected Connection _Connection;

        public BaseService()
        {
            _Connection = new Connection("Data Source=TECHNOBEL;Initial Catalog=SushiShop;User ID=sa;Password=test1234=;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", "System.Data.SqlClient");
        }
        public abstract T Get(int id);
        public abstract IEnumerable<T> GetAll();
        public abstract int Insert(T item);
        public abstract bool Update(T item);
        public abstract bool Delete(int id);
    }
}
