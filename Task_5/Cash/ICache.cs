namespace Task3.Cash
{
    public interface ICache
    {
        void Add(string key, object value);
        void Remove(string key);
        object Get(string key);

        void Clear();
    }
}
