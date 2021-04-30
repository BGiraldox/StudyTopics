namespace Services.Mocks
{
    public interface IWriteRepo<T> where T : IEntity
    {
        void Add(T entity);
    }
}