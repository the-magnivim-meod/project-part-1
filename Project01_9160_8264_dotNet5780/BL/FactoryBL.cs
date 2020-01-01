using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public abstract class FactoryBL
    {
        protected static IBL instance = null;

        /// <summary>
        /// returns the single instance of the Factory Dal
        /// </summary>
        /// <returns></returns>
        public static IBL GetBL()
        {
            if (instance == null)
            {
                instance = new BL_imp();
            }
            return instance;
        }
    }
}
