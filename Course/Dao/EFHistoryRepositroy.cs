using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return model.Кредитная_История.Where(x=>x.Заёмщик.Count == 0);
        }

        public IEnumerable<Кредитная_История> GetAllHistories()
        {
            return model.Кредитная_История;
        }

        public Кредитная_История findHistoryByPassport(long pass)
        {
            if (pass.ToString().Length != 10)
                return null;

            string stringSer = pass.ToString().Substring(0, 4);
            string stringNum = pass.ToString().Substring(4);

            int num = int.Parse(stringSer) ;
            int ser = int.Parse(stringNum);

            Заёмщик заёмщик = model.Заёмщик.Where(o => o.Номер_Паспорта == num && o.Серия_Паспорта == ser).FirstOrDefault();
            if (заёмщик == null)
                return null;

            Кредитная_История история = model.Кредитная_История.Where(o => o.ИД_Кредитной_Истории == заёмщик.ИД_Кредитной_Истории).FirstOrDefault();
            if (история == null)
                return null;

            история.Количество_Заявок++;
            история.Последний_Запрос = DateTime.Now;
            try
            {
                model.SaveChanges();
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
                return null;
            }

            return история;
        }

        public bool deleteHistoryById(int id)
        {
            Кредитная_История история = model.Кредитная_История.Where(o => o.ИД_Кредитной_Истории == id).FirstOrDefault();
            
            model.Кредитная_История.Remove(история);
            try
            {
                model.SaveChanges(); 
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

        public IEnumerable<Кредитная_История> findHistoryById(int id)
        {
            IEnumerable<Кредитная_История> история = model.Кредитная_История.Where(o => o.ИД_Кредитной_Истории == id);
            return история;
        }

        public void update(Кредитная_История история)
        {
            model.Entry(история).State = EntityState.Modified;
            model.SaveChanges();
        }

        public void saveHistory(Кредитная_История история)
        {
            model.Кредитная_История.Add(история);
            try
            {
                model.SaveChanges();
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