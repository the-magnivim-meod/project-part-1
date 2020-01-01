using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public abstract class FactoryDal
    {
        protected static Idal instance = null;
        public static Idal GetDal()
        {
            if (instance == null)
            {
                instance = new Dal_imp();
            }
            return instance;
        }
    }
}
