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

        public Кредитная_История findHistoryByPassport(int pass)
        {
            string stringSer = pass.ToString().Substring(0, 4);
            string stringNum = pass.ToString().Substring(4);

            int ser = int.Parse(stringSer) ;
            int num = int.Parse(stringNum);

            Заёмщик заёмщик = model.Заёмщик.Where(o => o.Номер_Паспорта == num && o.Серия_Паспорта == ser).FirstOrDefault();

            Кредитная_История история = model.Кредитная_История.Where(o => o.Заёмщик == заёмщик).FirstOrDefault(); //наверно equals и hashCode переопределить надо, а то пиздит

            return история;
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