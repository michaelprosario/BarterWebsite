using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarterWebsite.Models
{
    public class NeedsRepo
    {
        public int AddRecord(Need record)
        {
            var db = new Entities();

            db.Needs.Add(record);
            db.SaveChanges();

            return record.Id;
        }

        public bool RecordExists(int recordID)
        {
            var db = new Entities();
            Need record = db.Needs.Find(recordID);
            return record != null;
        }


        public void DeleteRecord(int id)
        {
            var db = new Entities();
            Need aRecord = db.Needs.Find(id);
            db.Needs.Remove(aRecord);
            db.SaveChanges();
        }

        public Need GetRecord(int id)
        {
            var db = new Entities();
            Need aRecord = db.Needs.Find(id);
            return aRecord;

        }

        public void UpdateRecord(Need record)
        {
            var db = new Entities();
            db.Entry(record).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        internal List<Need> GetNeedsByEmail(string emailAddress)
        {
            if (emailAddress == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentException();
            }

            var db = new Entities();

            return db.Needs.Where(a => a.User_Email_Needs == emailAddress).ToList();
        }

        internal List<Need> GetAll()
        {
            var db = new Entities();
            return db.Needs.ToList();
        }
    }
}