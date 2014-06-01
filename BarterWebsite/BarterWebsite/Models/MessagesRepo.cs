using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarterWebsite.Models
{
    public class MessagesRepo
    {
        public int AddRecord(Message record)
        {
            var db = new Entities();

            db.Messages.Add(record);
            db.SaveChanges();

            return record.Id;
        }

        public bool RecordExists(int recordID)
        {
            var db = new Entities();
            Message record = db.Messages.Find(recordID);
            return record != null;
        }


        public void DeleteRecord(int id)
        {
            var db = new Entities();
            Message aRecord = db.Messages.Find(id);
            db.Messages.Remove(aRecord);
            db.SaveChanges();
        }

        public Message GetRecord(int id)
        {
            var db = new Entities();
            Message aRecord = db.Messages.Find(id);
            return aRecord;

        }

        public void UpdateRecord(Message record)
        {
            var db = new Entities();
            db.Entry(record).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }
    }
}