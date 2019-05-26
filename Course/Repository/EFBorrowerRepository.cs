using Course.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Course.Repository
{
    public class EFBorrowerRepository
    {
        private EFDbContext context;

        public EFBorrowerRepository()
        {
            //задаём коннекшн из файла WebConfig
            context = new EFDbContext(ConfigurationManager.ConnectionStrings[2].ConnectionString);
        }

        public IEnumerable<Заёмщик> GetBorrowers()
        {
            return context.Заёмщики;
        }

        public void saveBorrower(Заёмщик заёмщик)
        {
            context.Заёмщики.Add(заёмщик);
            try
            {
                context.SaveChanges();
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

        public Заёмщик GetBoorrowerById(int id)
        {
            return context.Заёмщики.FirstOrDefault(x => x.ИД_Заёмщика == id);
        }
    }
}