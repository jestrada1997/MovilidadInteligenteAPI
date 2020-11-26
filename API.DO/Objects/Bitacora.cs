using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DO.Objects
{
    public class Bitacora
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdBitacora { get; set; }
        public string Accion { get; set; }
        public string Error { get; set; }
        public DateTime Fecha { get; set; }
        public string IdUsuario { get; set; }
        public bool Estado { get; set; }
    }
}
