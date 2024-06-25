using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinesePoetryLibrary.Src.db
{
    [BsonIgnoreExtraElements]
    public class Author
    {

        [BsonId]
        public ObjectId Mid { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("app_id")]
        public string AppId{ get; set; }
    }
}
