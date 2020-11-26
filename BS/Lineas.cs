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
    public class Lineas : IRepository<data.Linea>
    {
        //se implementea el repositorio de mongo a lo interno para que solo la clase lo vea
        internal ApiContext _repository = new ApiContext();

        //agregar la colleccion
        private IMongoCollection<Linea> Collection;

        //constructor
        public Lineas()
        {
            //Si la colleccion no existe la crea, de lo contrario la carga
            Collection = _repository.db.GetCollection<Linea>("Lineas");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<Linea>.Filter.Eq("_id", new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<Linea> GetAllById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<IEnumerable<Linea>> GetAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(Linea Linea)
        {
            await Collection.InsertOneAsync(Linea);
        }

        public async Task Update(Linea Linea)
        {
            var filter = Builders<Linea>.Filter.Eq(s => s.IdLinea, Linea.IdLinea);
            await Collection.ReplaceOneAsync(filter, Linea);
        }
    }
}
