using Course.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course.Models
{
    public class ЗаёмщикДоговоры
    {
        public IEnumerable<Заёмщик> заёмщики { get; set; }

        public Кредитный_Договор договор { get; set; }

        public ЗаёмщикДоговоры()
        {
            EFBorrowerRepository repository = new EFBorrowerRepository();
            договор = new Кредитный_Договор();
            заёмщики = repository.GetBorrowers();
        }
    }
}