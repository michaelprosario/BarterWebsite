using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarterWebsite.Models
{
    public class AvailableRepo
    {

        public int AddRecord(Available record)
        {
            var db = new Entities();

            db.Availables.Add(record);
            db.SaveChanges();

            return record.Id;
        }

        public bool RecordExists(int recordID)
        {
            var db = new Entities();
            Available record = db.Availables.Find(recordID);
            return record != null;
        }


        public void DeleteRecord(int id)
        {
            var db = new Entities();
            Available aRecord = db.Availables.Find(id);
            db.Availables.Remove(aRecord);
            db.SaveChanges();
        }

        public Available GetRecord(int id)
        {
            var db = new Entities();
            Available aRecord = db.Availables.Find(id);
            return aRecord;

        }

        public void UpdateRecord(Available record)
        {
            var db = new Entities();
            db.Entry(record).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

    }
}