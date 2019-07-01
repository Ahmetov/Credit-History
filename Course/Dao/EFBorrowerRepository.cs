using Course.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace Course.Repository
{
    public class EFBorrowerRepository
    {
        private DBModel dBModel = new DBModel();

        public DBModel getModel()
        {
            return dBModel;
        }

        public EFBorrowerRepository()
        {
            
        }

        public IEnumerable<Заёмщик> GetBorrowers()
        {
            return dBModel.Заёмщик;
        }

        public void saveBorrower(Заёмщик заёмщик)
        {
            Кредитная_История история = dBModel.Кредитная_История.Where(x => x.ИД_Кредитной_Истории == заёмщик.ИД_Кредитной_Истории).FirstOrDefault();

            dBModel.Заёмщик.Add(заёмщик);
            try
            {
                dBModel.SaveChanges();
                if (заёмщик.ИД_Кредитной_Истории != null)
                    dBModel.setQuanity(заёмщик.ИД_Заёмщика);
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
            Кредитная_История иистория = dBModel.Кредитная_История.Where(x => x.ИД_Кредитной_Истории == заёмщик.ИД_Кредитной_Истории).FirstOrDefault();
        }

        public bool deleteBorrowerById(int id)
        {
            Заёмщик заёмщик = dBModel.Заёмщик.Where(o => o.ИД_Заёмщика == id).FirstOrDefault();
            dBModel.Заёмщик.Remove(заёмщик);
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

        public void update(ЗаёмщикАдрес заёмщикАдрес)
        {

            if (заёмщикАдрес.заёмщик.ИД_Кредитной_Истории != null)
                dBModel.setQuanity(заёмщикАдрес.заёмщик.ИД_Заёмщика);

            dBModel.Entry(заёмщикАдрес.адрес).State = EntityState.Modified;
            dBModel.Entry(заёмщикАдрес.заёмщик).State = EntityState.Modified;
            dBModel.SaveChanges();

        }

        public Заёмщик GetBoorrowerById(int id)
        {
                Заёмщик заёмщик = dBModel.Заёмщик.Where(x => x.ИД_Заёмщика == id).FirstOrDefault();
                return заёмщик;
        }
    }
}