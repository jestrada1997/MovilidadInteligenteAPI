using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;   

namespace API.DO.Objects
{
    public class Pago
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdPago { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUsuario { get; set; }
        public string IdUnidad { get; set; }
        public int Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public bool Estado { get; set; }
    }
}
