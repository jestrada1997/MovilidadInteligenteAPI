using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class ApiContext
    {
        //
        public MongoClient client;

        //
        public IMongoDatabase db;

        //constructor para la conexion
        public ApiContext()
        {
            client = new MongoClient("mongodb+srv://Corella:ZTWM7cSEXYwLbHZ4@autotransportes.xd9c7.mongodb.net/<dbname>?retryWrites=true&w=majority");
            db = client.GetDatabase("MobilidadInteligente");
        }
    }
}
