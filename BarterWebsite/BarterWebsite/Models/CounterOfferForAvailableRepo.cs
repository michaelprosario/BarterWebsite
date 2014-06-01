using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarterWebsite.Models
{
    public class CounterOfferForAvailableRepo
    {
        public int AddRecord(CounterOfferForAvailable record)
        {
            var db = new Entities();

            db.CounterOfferForAvailables.Add(record);
            db.SaveChanges();

            return record.Id;
        }

        public bool RecordExists(int recordID)
        {
            var db = new Entities();
            CounterOfferForAvailable record = db.CounterOfferForAvailables.Find(recordID);
            return record != null;
        }


        public void DeleteRecord(int id)
        {
            var db = new Entities();
            CounterOfferForAvailable aRecord = db.CounterOfferForAvailables.Find(id);
            db.CounterOfferForAvailables.Remove(aRecord);
            db.SaveChanges();
        }

        public CounterOfferForAvailable GetRecord(int id)
        {
            var db = new Entities();
            CounterOfferForAvailable aRecord = db.CounterOfferForAvailables.Find(id);
            return aRecord;

        }

        public void UpdateRecord(CounterOfferForAvailable record)
        {
            var db = new Entities();
            db.Entry(record).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }
    }
}