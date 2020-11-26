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
    public class Linea
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdLinea { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }
        public int CodigoCTP { get; set; }
        public bool Estado { get; set; }
    }
}
