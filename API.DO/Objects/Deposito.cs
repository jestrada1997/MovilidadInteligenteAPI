using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DO.Objects
{
    public class Deposito
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdDeposito { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUsuario { get; set; }
        public int Monto { get; set; }
        public DateTime FechaDeposito { get; set; }
        public bool Estado { get; set; }
    }
}
