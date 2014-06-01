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
            var db = new Entities();

            db.Categories.Add(aCategory);
            db.SaveChanges();

            return aCategory.Id;
        }

        public bool RecordExists(int recordID)
        {
            var db = new Entities();
            Category aCategory = db.Categories.Find(recordID);
            return aCategory != null;
        }


        public void DeleteRecord(int id)
        {
            var db = new Entities();
            Category aRecord = db.Categories.Find(id);
            db.Categories.Remove(aRecord);
            db.SaveChanges();
        }

        public Category GetRecord(int id)
        {
            var db = new Entities();
            Category aRecord = db.Categories.Find(id);
            return aRecord;

        }

        public void UpdateRecord(Category record)
        {
            var db = new Entities();
            db.Entry(record).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>();
            using (var db = new Entities())
            {
                
                foreach (var c in db.Categories)
                {
                    list.Add(c);
                }
            }

            return list;
        }







    }
}