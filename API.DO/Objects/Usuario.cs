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
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido1 { get; set; }
        [Required]
        public string Apellido2 { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required]
        public string Telefono { get; set; }
        public int Saldo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; }
    }
}
