using System;
namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        bool IsAdded(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        T Get<T>(string key);
        object Get(string key);
    }
}
