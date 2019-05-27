using Course.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Course.Repository
{
    public class EFBankRepository
    {
        private DBModel dBModel = new DBModel();

        public IEnumerable<Банк> GetBanks()
        {
            return dBModel.Банк;
        }

        public bool deleteBankById(int id)
        {
            Банк банк = dBModel.Банк.Where(o => o.ИД_Банка == id).FirstOrDefault();
            //dBModel.Банк.Attach(банк);
            dBModel.Банк.Remove(банк);
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

        public void saveBank(Банк банк)
        {
            dBModel.Банк.Add(банк);
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
    }
}