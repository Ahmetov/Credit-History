using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course.Models
{
    public class БанкАдрес
    {
        public Банк банк { get; set; }
        public Адрес адрес { get; set; }

        public БанкАдрес()
        {
            банк = new Банк();
            адрес = new Адрес();
            банк.Адрес = адрес;
        }
    }
}