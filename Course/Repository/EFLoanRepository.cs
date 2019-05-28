using System;
using System.Collections.Generic;
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
            try
            {
                dBModel.SaveChanges(); //Адрес 2 раза не может быть null, exception
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

        public bool deleteLoanById(int id)
        {
            Кредитный_Договор договор = dBModel.Кредитный_Договор.Where(o => o.ИД_Договора == id).FirstOrDefault();
            //dBModel.Банк.Attach(банк);
            dBModel.Кредитный_Договор.Remove(договор);
            try
            {
                dBModel.SaveChanges(); //Адрес 2 раза не может быть null, exception
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