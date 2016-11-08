using System;
using System.Collections.Generic;
using System.Linq;
using nsProduct;

namespace nsRepoProduct {
    public interface IProduct {
        List<Product> search(string searchTerm); 
        List<Product> getAll(); 
        void add (Product p);
        bool delete(int id);
        Product get(int id);
        Product update(int id, Product p);
    }

    public class ProductAPI : IProduct {
        private DB db;
        public ProductAPI (DB db) {
            this.db = db;
        }
        public void add (Product p) {
            db.Products.Add(p);
        }
        public List<Product> getAll() {
            return db.Products.ToList();
        }
        public List<Product> search(string searchTerm){
            List<Product> productsWithSearchTerm = new List<Product>();
            foreach (Product p in db.Products){
                if (p.Title.ToLower().Contains(searchTerm) || p.Description.ToLower().Contains(searchTerm)) {
                    productsWithSearchTerm.Add(p);
                }  
            }
            return productsWithSearchTerm;
        }
        public Product get(int id) {
            return db.Products.First(x => x.Id == id);
        }
        public Product update(int id, Product p) {
            if (db.Products.Remove(db.Products.First(x => x.Id == id)) != null) {
                db.Products.Add(p);
                return p;
            } else { return null; }
        }
        public bool delete(int id) {
            return (db.Products.Remove(db.Products.First(x => x.Id == id)) != null) ? true : false;
        }
    }
}