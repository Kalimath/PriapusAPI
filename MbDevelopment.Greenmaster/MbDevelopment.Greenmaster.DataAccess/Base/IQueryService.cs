using MbDevelopment.Greenmaster.Core.Botanical;

namespace MbDevelopment.Greenmaster.DataAccess.Base;

public interface IQueryService<T1, in T2>
    {
        public Task Add(T1 newObject);
        public Task<T1?> GetById(T2 id);
        public Task<List<T1>> GetAll();
        public Task Update(T1 updatedObject);
        public Task Delete(T2 id);
        public Task<bool> ExistsWithId(T2 id);
}