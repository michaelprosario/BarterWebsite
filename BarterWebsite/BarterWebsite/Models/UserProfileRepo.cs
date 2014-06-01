using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarterWebsite.Models
{
    public class UserProfileRepo
    {
        public int AddRecord(UserProfile r)
        {
            var db = new Entities();
            db.UserProfiles.Add(r);
            db.SaveChanges();

            return r.UserId;
        }

        public bool RecordExists(int recordID)
        {
            var db = new Entities();
            UserProfile r = db.UserProfiles.Find(recordID);
            return r != null;
        }

        public void DeleteRecord(int recordID)
        {
            var db = new Entities();
            var aRecord = db.UserProfiles.Find(recordID);
            db.UserProfiles.Remove(aRecord);
            db.SaveChanges();
        }

        public UserProfile GetRecord(int recordID)
        {
            var db = new Entities();
            var aRecord = db.UserProfiles.Find(recordID);
            return aRecord;
        }

        public void UpdateRecord(UserProfile record)
        {
            var db = new Entities();
            db.Entry(record).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }
    }
}