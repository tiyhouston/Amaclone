using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using nsStore;

namespace StoreRepo {
    public interface IStore { 
        List<Store>getAll(); 
        void add (Store s);
        bool delete(int id);
        Store get(int id);
        Store update(int id, Store s);
        List<Store> search(string s);
    }

    public class StoreAPI : IStore {
        private DB db;
        public StoreAPI (DB db) {
            this.db = db;
        }
        public void add (Store s) {
            db.Stores.Add(s);
            db.SaveChanges();
        }
        public List<Store> getAll() {
            return db.Stores.ToList();
        }
        public List<Store> search(string searchTerm){
            List<Store> storesWithSearchTerm = new List<Store>();
            foreach (Store s in db.Stores){
                if (s.Title.ToLower().Contains(searchTerm)) {
                    storesWithSearchTerm.Add(s);
                }  
            }
            return storesWithSearchTerm;
        }
        public Store get(int id) {
            return db.Stores.First(x => x.Id == id);
        }
        public Store update(int id, Store s) {
            if (db.Stores.Remove(db.Stores.First(x => x.Id == id)) != null) {
                db.Stores.Add(s);
                db.SaveChanges();
                return s;
            } else { return null; }
        }
        public bool delete(int id) {
            return (db.Stores.Remove(db.Stores.First(x => x.Id == id)) != null) ? true : false;
        }
    }
}