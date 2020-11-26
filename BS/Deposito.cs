using API.DO.Objects;
using DAL.EF;
using MongoDB.Bson;
using MongoDB.Driver;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = API.DO.Objects;

namespace BS
{
    public class Depositos : IRepository<data.Deposito>
    {
        //se implementea el repositorio de mongo a lo interno para que solo la clase lo vea
        internal ApiContext _repository = new ApiContext();

        //agregar la colleccion de Depositos
        private IMongoCollection<Deposito> Collection;

        //constructor
        public Depositos()
        {
            //Si la colleccion no existe la crea, de lo contrario la carga
            Collection = _repository.db.GetCollection<Deposito>("Depositos");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<Deposito>.Filter.Eq("_id", new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<Deposito> GetAllById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<IEnumerable<Deposito>> GetAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(Deposito Deposito)
        {
            await Collection.InsertOneAsync(Deposito);
        }

        public async Task Update(Deposito Deposito)
        {
            var filter = Builders<Deposito>.Filter.Eq(s => s.IdDeposito, Deposito.IdDeposito);
            await Collection.ReplaceOneAsync(filter, Deposito);
        }
    }
}
