using System.Collections.Generic;

namespace Services.Mocks
{
    public interface IReadRepo<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
    }
}