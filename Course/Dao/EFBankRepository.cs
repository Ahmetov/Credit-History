﻿using Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<Банк> findByName(string name)
        {
            if (name == null)
                return null;

            IEnumerable<Банк> банк = dBModel.Банк.Where(o => o.Название.Contains(name));

            return банк;
        }

        public bool deleteBankById(int id)
        {
            Банк банк = dBModel.Банк.Where(o => o.ИД_Банка == id).FirstOrDefault();
            Кредитный_Договор договор = dBModel.Кредитный_Договор.Where(o => o.ИД_Банка == банк.ИД_Банка).FirstOrDefault();
            if (договор != null)
                dBModel.Кредитный_Договор.Remove(договор);
            dBModel.Банк.Remove(банк);
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

        public Банк findBankById(int id)
        {
            Банк банк = dBModel.Банк.Where(o => o.ИД_Банка == id).FirstOrDefault();
            return банк;
        }
        
        public void update (БанкАдрес банкАдрес )
        {
            dBModel.Entry(банкАдрес.адрес).State = EntityState.Modified;
            dBModel.Entry(банкАдрес.банк).State = EntityState.Modified;

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

        public void saveBank(Банк банк)
        {
            dBModel.Банк.Add(банк);
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
    }
}