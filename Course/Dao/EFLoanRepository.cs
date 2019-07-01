using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Course.Repository
{
    public class EFLoanRepository
    {
        private DBModel dBModel = new DBModel();

        public IEnumerable<Кредитный_Договор> GetLoans()
        {
            return dBModel.Кредитный_Договор;
        }

        public void saveLoan(Кредитный_Договор договор)
        {
            dBModel.Кредитный_Договор.Add(договор);

            Заёмщик заёмщик = dBModel.Заёмщик.Where(x => x.ИД_Заёмщика == договор.ИД_Заёмщика).FirstOrDefault();

            заёмщик.Кредитная_История.Количество_Счетов++;
            
            if( заёмщик.Кредитный_Договор.Count <= 1)
            {
                заёмщик.Кредитная_История.Открыт_Первый = договор.Дата_Заключения;
                заёмщик.Кредитная_История.Открыт_Последний = договор.Дата_Заключения;
            } else
            {
                заёмщик.Кредитная_История.Открыт_Последний = договор.Дата_Заключения;
            }


            try
            {
                dBModel.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Trace.Write("Object: " + validationError.Entry.Entity.ToString());
                    Trace.Write("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Trace.Write(err.ErrorMessage + "");
                    }
                }
            }
        }

        public IEnumerable<Кредитный_Договор> findLoanById(int id)
        {
            IEnumerable<Кредитный_Договор> договор = dBModel.Кредитный_Договор.Where(o => o.ИД_Договора == id);
            return договор;
        }

        public void update(Кредитный_Договор договор)
        {
            dBModel.Entry(договор).State = EntityState.Modified;
            dBModel.SaveChanges();
        }

        public bool deleteLoanById(int id)
        {
            Кредитный_Договор договор = dBModel.Кредитный_Договор.Where(o => o.ИД_Договора == id).FirstOrDefault();
            Заёмщик заёмщик = dBModel.Заёмщик.Where(x => x.ИД_Заёмщика == договор.ИД_Заёмщика).FirstOrDefault();

            заёмщик.Кредитная_История.Количество_Счетов--;


            dBModel.Кредитный_Договор.Remove(договор);

            
            try
            {
                dBModel.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Trace.Write("Object: " + validationError.Entry.Entity.ToString());
                    Trace.Write("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Trace.Write(err.ErrorMessage + "");
                    }
                }
                return false;
            }
        }
    }
}