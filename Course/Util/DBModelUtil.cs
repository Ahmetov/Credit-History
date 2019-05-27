using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course.Util
{
    public class DBModelUtil
    {
        private static DBModel model = new DBModel();

        private DBModelUtil()
        {
        }

        public static DBModel GetDBModel()
        {
            return model;
        }

    }
}