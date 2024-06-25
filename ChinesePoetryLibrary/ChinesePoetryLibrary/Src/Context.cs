using ChinesePoetryLibrary.Src.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinesePoetryLibrary.Src
{
    public class Context
    {

        private MongoDBManager mgoDbMgr;

        public Context() 
        {
            mgoDbMgr = new MongoDBManager();
        }

        public bool Init()
        {
            if (!mgoDbMgr.Connect("mongodb://localhost:27017", "sailfish")) 
            { 
                return false;
            }

            return true;
        }

        public void Test()
        {
            mgoDbMgr.Test();
        }

    }
}
