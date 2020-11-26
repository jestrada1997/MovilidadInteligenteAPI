using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DO.Objects
{
    public class Unidad
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUnidad { get; set; }
        public string Descripcion { get; set; }
        public string Placa { get; set; }
        public bool Estado { get; set; }
    }
}
