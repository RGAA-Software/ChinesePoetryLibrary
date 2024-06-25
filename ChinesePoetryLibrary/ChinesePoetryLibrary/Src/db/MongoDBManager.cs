using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ChinesePoetryLibrary.Src.db
{
    public class MongoDBManager
    {
        private IMongoDatabase db;

        public MongoDBManager()
        {

        }

        public bool Connect(string url, string dbName)
        {
            var client = new MongoClient(url);
            db = client.GetDatabase(dbName);
            return db != null;
        }

        public void Test()
        {
            var collection = db.GetCollection<Author>("c_application");
            var data = collection.Find(new BsonDocument()).ToList();
            data.ForEach(x =>
            {
               Debug.WriteLine("===>" + x.ToString() + " - " +  x.AppId);
            });
        }
    }
}
