using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public abstract class FactoryDal
    {
        protected static IDal instance = null;

        /// <summary>
        /// returns the single instance of the Factory Dal
        /// </summary>
        /// <returns></returns>
        public static IDal GetDal()
        {
            if (instance == null)
            {
                instance = new Dal_imp();
            }
            return instance;
        }
    }
}
