using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarterWebsite.Models
{
    public class CitiesRepo
    {
        public int AddRecord(City record)
        {
            var db = new Entities();

            db.Cities.Add(record);
            db.SaveChanges();

            return record.Id;
        }

        public bool RecordExists(int recordID)
        {
            var db = new Entities();
            City record = db.Cities.Find(recordID);
            return record != null;
        }


        public void DeleteRecord(int id)
        {
            var db = new Entities();
            City aRecord = db.Cities.Find(id);
            db.Cities.Remove(aRecord);
            db.SaveChanges();
        }

        public City GetRecord(int id)
        {
            var db = new Entities();
            City aRecord = db.Cities.Find(id);
            return aRecord;

        }

        public void UpdateRecord(City record)
        {
            var db = new Entities();
            db.Entry(record).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }
    }
}