using Repository;
using DAL.EF;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = API.DO.Objects;
using API.DO.Objects;

namespace BS
{
    public class Usuarios : IRepository<data.Usuario>
    {
        //se implementea el repositorio de mongo a lo interno para que solo la clase lo vea
        internal ApiContext _repository = new ApiContext();

        //agregar la colleccion 
        private IMongoCollection<Usuario> Collection;

        //constructor
        public Usuarios()
        {
            //Si la colleccion no existe la crea, de lo contrario la carga
            Collection = _repository.db.GetCollection<Usuario>("Usuarios");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<Usuario>.Filter.Eq("_id", new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<Usuario> GetAllById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(Usuario usuario)
        {
            await Collection.InsertOneAsync(usuario);
        }

        public async Task Update(Usuario usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq("_id", usuario.IdUsuario);

            await Collection.ReplaceOneAsync(filter, usuario);
            
        }
    }
}
