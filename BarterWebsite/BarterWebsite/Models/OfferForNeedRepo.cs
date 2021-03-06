﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarterWebsite.Models
{
    public class OfferForNeedRepo
    {
        public int AddRecord(OfferForNeed record)
        {
         

            var db = new Entities();

            db.OfferForNeeds.Add(record);
            db.SaveChanges();

            return record.Id;
        }

        public bool RecordExists(int recordID)
        {
            var db = new Entities();
            CounterOfferForNeed record = db.CounterOfferForNeeds.Find(recordID);
            return record != null;
        }


        public void DeleteRecord(int id)
        {
            var db = new Entities();
            CounterOfferForNeed aRecord = db.CounterOfferForNeeds.Find(id);
            db.CounterOfferForNeeds.Remove(aRecord);
            db.SaveChanges();
        }

        public CounterOfferForNeed GetRecord(int id)
        {
            var db = new Entities();
            CounterOfferForNeed aRecord = db.CounterOfferForNeeds.Find(id);
            return aRecord;

        }

        public void UpdateRecord(CounterOfferForNeed record)
        {
            var db = new Entities();
            db.Entry(record).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        internal List<OfferForNeed> GetOffersForByNeedID(int needID)
        {
            var db = new Entities();

            return db.OfferForNeeds.Where(a => a.Need_ID == needID).ToList(); 

            //
        }
    }
}