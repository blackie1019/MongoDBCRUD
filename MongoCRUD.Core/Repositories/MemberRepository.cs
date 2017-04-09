using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

using MongoCRUD.Core.Pocos;

namespace MongoCRUD.Core.Repositories
{
    public sealed class MemberRepository : CommonRepository, IMemberRepository<Member>
    {
        private static readonly Lazy<MemberRepository> lazy = new Lazy<MemberRepository>(() => new MemberRepository());

        public static MemberRepository Instance { get { return lazy.Value; } }

        private IMongoCollection<Member> Collection { get; set; }

        private MemberRepository()
        {
            this.Collection = this.Database.GetCollection<Member>("member");
        }

        public IList<Member> Get()
        {
            return this.Collection.Find(new BsonDocument()).ToList();
        }

        public Member Get(string id)
        {
            var filter = this.GenerateFilterInput(id);

            return this.Collection.Find(filter).FirstOrDefault();
        }

        public void Insert(Member dataObject)
        {
            this.Collection.InsertOne(dataObject);
        }

        public UpdateResult Update(Member dataObject)
        {
            var input = this.GenerateUpdateInput(dataObject);

            return this.Collection.UpdateOne(input.Item1, input.Item2);
        }

        public Member UpdateAndFitch(Member dataObject)
        {
            var input = this.GenerateUpdateInput(dataObject);
            var option = new FindOneAndUpdateOptions<Member>()
            {
                ReturnDocument = ReturnDocument.After
            };

            return this.Collection.FindOneAndUpdate(input.Item1, input.Item2,option);
        }

        public DeleteResult Delete(string id)
        {
            var filter = this.GenerateFilterInput(id);
            var result = this.Collection.DeleteOne(filter);

            return result;
        }

        private Tuple<FilterDefinition<Member>, UpdateDefinition<Member>> GenerateUpdateInput(Member dataObject)
        {
            var filter = this.GenerateFilterInput(dataObject.Id.ToString());
            var update = Builders<Member>.Update.Set(s => s.Balance, dataObject.Balance);

            return Tuple.Create(filter, update);
        }

        private FilterDefinition<Member> GenerateFilterInput(string id)
        {
            return Builders<Member>.Filter.Eq("_id", ObjectId.Parse(id));
        }
    }
}
