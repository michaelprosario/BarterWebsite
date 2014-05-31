using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarterWebsite.Models
{
    public class CategoriesRepo
    {

        public int AddRecord(Category aCategory)
        {
            BarterWebsite.Models.Entities db = new Entities();

            db.Categories.Add(aCategory);
            db.SaveChanges();

            return aCategory.Id;
        }

        public bool RecordExists(int recordID)
        {
            BarterWebsite.Models.Entities db = new Entities();
            Category aCategory = db.Categories.Find(recordID);
            return aCategory != null;
        }


        public void DeleteRecord(int id)
        {
            BarterWebsite.Models.Entities db = new Entities();
            Category aRecord = db.Categories.Find(id);
            db.Categories.Remove(aRecord);
            db.SaveChanges();
        }

        public Category GetRecord(int id)
        {
            BarterWebsite.Models.Entities db = new Entities();
            Category aRecord = db.Categories.Find(id);
            return aRecord;

        }

        public void UpdateRecord(Category record2)
        {
            BarterWebsite.Models.Entities db = new Entities();
            db.Entry(record2).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }



    }
}