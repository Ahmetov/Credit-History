using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course.Models
{
    public class ЗаёмщикАдрес
    {
        public Заёмщик заёмщик { get; set; }
        public Адрес адрес { get; set; }

        public ЗаёмщикАдрес()
        {
            заёмщик = new Заёмщик();
            адрес = new Адрес();
            заёмщик.Адрес = адрес;
        }
    }
}