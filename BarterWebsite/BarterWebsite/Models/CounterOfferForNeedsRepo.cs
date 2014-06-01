using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarterWebsite.Models
{
    public class CounterOfferForNeedsRepo
    {
        public int AddRecord(CounterOfferForNeed record)
        {
            var db = new Entities();

            db.CounterOfferForNeeds.Add(record);
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
    }
}