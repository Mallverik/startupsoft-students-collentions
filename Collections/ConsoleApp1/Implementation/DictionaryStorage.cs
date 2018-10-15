using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class DictionaryStorage<T> : IStorage<T> where T : IStorageObject
    {
        Dictionary<T, T> StorageDictionary = new Dictionary<T,T>();
        //TODO: Implement
        public void Clear()
        {
            StorageDictionary.Clear();
        }

        public int Count()
        {
           return StorageDictionary.Count;
        }

        public bool Exists(string id)
        {
            foreach(var key in StorageDictionary.Keys)
            {
                if (id.Equals(key.Id))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<T> Filter(Predicate<T> predicate)
        {
            foreach (var items in StorageDictionary.Values)
            {
                if (predicate(items) == true)
                {
                    yield return items;
                }
            }
        }

        public T GetById(string id)
        {
            foreach (var keys in StorageDictionary.Keys)
            {
                
                if (id.Equals(keys.Id))
                {
                    return StorageDictionary[keys];
                }
            }
            throw new ArgumentException();
        }

        public void Insert(T item)
        {
            if (StorageDictionary.ContainsKey(item))
            {
                throw new ArgumentException();
            }
            StorageDictionary.Add(item, item);

        }

        public void InsertMany(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (StorageDictionary.ContainsKey(item))
            {
                throw new ArgumentException();
            }
                StorageDictionary.Add(item, item);
            }
        }

        public bool Update(T element)
        {
            if (StorageDictionary.ContainsKey(element))
            {
                StorageDictionary[element] = element;
                return true;
            }
            return false;
        }
    }
}