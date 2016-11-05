using System;
using System.Collections.Generic;
using System.Linq;
using nsProduct;

namespace nsRepoProduct {
    public interface IProduct {
        List<Product> search(string searchTerm); 
        List<Product> getAll(); 
        void add (List<Product> p);
        bool delete(int id);
        Product get(int id);
        Product update(int id, Product s);
    }

    public class ProductAPI : IProduct {
        private List<Product> products = new List<Product>();
        private int idCount = 0;
        // Constructor
        public ProductAPI() {
            // TODO use this to SEED products
        }

        // Methods
        public void add (List<Product> p) {
            foreach (Product pToAdd in p)
            {
                pToAdd.Id = idCount++;
                pToAdd.CreatedAt = DateTime.Now;
                
                int urlCount = 0;
                foreach (URL iURL in pToAdd.ImageURLs)
                {
                    iURL.Id = urlCount++;
                    iURL.CreatedAt = DateTime.Now;
                    iURL.ProductId = pToAdd.Id;
                }
                products.Add(pToAdd);
            }
        }

        public List<Product> getAll() => products;

        public List<Product> search(string searchTerm){
            List<Product> productsWithSearchTerm = new List<Product>();
            foreach (Product listWS in products){
                if (listWS.Title.Contains(searchTerm) || listWS.Description.Contains(searchTerm)) {
                    productsWithSearchTerm.Add(listWS);
                }  
            }
            return productsWithSearchTerm;
        }
        
        public Product get(int id) => products.First(x => x.Id == id);

        public Product update(int id, Product p) {
            if (products.Remove(products.First(x => x.Id == id))) {
                products.Add(p);
                return products.Last();
            } else { return null; }
        }

        public bool delete(int id) => (products.Remove(products.First(x => x.Id == id))) ? true : false;
    }
}