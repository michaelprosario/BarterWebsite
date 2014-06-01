using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarterWebsite.Models
{
    public class OfferForAvailableRepo
    {
        public int AddRecord(OfferForAvailable record)
        {
            var db = new Entities();

            db.OfferForAvailables.Add(record);
            db.SaveChanges();

            return record.Id;
        }

        public bool RecordExists(int recordID)
        {
            var db = new Entities();
            OfferForAvailable record = db.OfferForAvailables.Find(recordID);
            return record != null;
        }


        public void DeleteRecord(int id)
        {
            var db = new Entities();
            OfferForAvailable aRecord = db.OfferForAvailables.Find(id);
            db.OfferForAvailables.Remove(aRecord);
            db.SaveChanges();
        }

        public OfferForAvailable GetRecord(int id)
        {
            var db = new Entities();
            OfferForAvailable aRecord = db.OfferForAvailables.Find(id);
            return aRecord;

        }

        public void UpdateRecord(OfferForAvailable record)
        {
            var db = new Entities();
            db.Entry(record).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }
    }
}