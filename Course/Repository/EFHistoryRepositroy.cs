using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Course.Repository
{
    public class EFHistoryRepositroy
    {
        private DBModel model = new DBModel();

        public IEnumerable<Кредитная_История> GetHistories()
        {
            return model.Кредитная_История;
        }

        public bool deleteHistoryById(int id)
        {
            Кредитная_История история = model.Кредитная_История.Where(o => o.ИД_Кредитной_Истории == id).FirstOrDefault();
            //dBModel.Банк.Attach(банк);
            model.Кредитная_История.Remove(история);
            try
            {
                model.SaveChanges(); //Адрес 2 раза не может быть null, exception
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

        public void saveHistory(Кредитная_История история)
        {
            model.Кредитная_История.Add(история);
            try
            {
                model.SaveChanges(); //Адрес 2 раза не может быть null, exception
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