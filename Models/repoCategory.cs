using System;
using System.Collections.Generic;
using System.Linq;
using nsCategory;

namespace nsCategory {

    public interface ICategory {
        List<Category> getAll(); 
        void add (Category c);
        bool delete(int id);
        Category get(int id);
        Category update(int id, Category c);
    }

    public class CategoryAPI : ICategory {

        // Constructor
        private DB db;
        public CategoryAPI (DB db) {
            this.db = db;
        }

        // Methods - Add New Category
        public void add (Category c) {
            db.Categories.Add(c);
            db.SaveChanges();
        }

        //Get All Categories
        public List<Category> getAll() {
            return db.Categories.ToList();
        }

        //Get One Category using Id
        public Category get(int id) {
            return db.Categories.First(x => x.Id == id);
        }

        //Update Existing Category if matching Id is found
        public Category update(int id, Category c) {
            if (db.Categories.Remove(db.Categories.First(x => x.Id == id)) != null) {
                db.Categories.Add(c);
                db.SaveChanges();
                return c;
            } else {
                return null;
            }
        }

        // Delete Category if matching Id is found
        public bool delete(int id) {
            Category c = db.Categories.First(x => x.Id == id); 
            return (db.Categories.Remove(c) != null) ? true : false;
        }
    }
}