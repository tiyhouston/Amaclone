using System;
using System.Collections.Generic;
using System.Linq;
using nsCategory; // I'm assuming ns stands for namespace?

namespace nsRepoCategory {
    public interface ICategory {
        List<Category> getAll(); 
        void add (List<Category> c);
        bool delete(int id);
        Category get(int id);
        Category update(int id, Category c);
    }
    public class CategoryAPI : ICategory {
        private List<Category> categories = new List<Category>(); //why private??
        private int idCount = 0;
        // Constructor
        public CategoryAPI() {
            // Seed data goes here
        }

        // Methods - Add New Category
        public void add (List<Category> c) {
            foreach (Category cToAdd in c)
            {
                cToAdd.Id = idCount++;
                cToAdd.CreatedAt = DateTime.Now;        
                categories.Add(cToAdd);
            }
        }
        //Get All Categories
        public List<Category> getAll() => categories;

        //Get One Category using Id
        public Category get(int id) => categories.First(x => x.Id == id);

        //Update Existing Category if matching Id is found
        public Category update(int id, Category c) {
            if (categories.Remove(categories.First(x => x.Id == id))) {
                categories.Add(c);
                return categories.Last();
            } else { return null; }
        }
        // Delete Category if matching Id is found
        public bool delete(int id) => (categories.Remove(categories.First(x => x.Id == id))) ? true : false;
    }
}