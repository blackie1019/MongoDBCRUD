using System.Collections.Generic;

using MongoDB.Driver;

namespace MongoCRUD.Core.Repositories
{
    public interface IMemberRepository<T>
    {
        IList<T> Get();

        T Get(string id);

        void Insert(T dataObject);

        UpdateResult Update(T dataObject);
        
        T UpdateAndFitch(T dataObject);

        DeleteResult Delete(string id);

    }
}