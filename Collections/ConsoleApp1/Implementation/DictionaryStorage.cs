using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class DictionaryStorage<T> : IStorage<T> where T : IStorageObject
    {
        Dictionary<string, T> StorageDictionary = new Dictionary<string,T>();
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
            return StorageDictionary.ContainsKey(id);
            
        }

        public IEnumerable<T> Filter(Predicate<T> predicate)
        {
            foreach (var items in StorageDictionary.Values)
            {
                if (predicate(items))
                {
                    yield return items;
                }
            }
        }

        public T GetById(string id)
        {

            if (StorageDictionary.ContainsKey(id))
            {
                return StorageDictionary[id];
            }
            
            throw new ArgumentException();
        }

        public void Insert(T item)
        {
            if (StorageDictionary.ContainsKey(item.Id))
            {
                throw new ArgumentException();
            }
            StorageDictionary.Add(item.Id, item);

        }

        public void InsertMany(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Insert(item);   
            }
        }

        public bool Update(T element)
        {
            if (StorageDictionary.ContainsKey(element.Id))
            {
                StorageDictionary[element.Id] = element;
                return true;
            }
            return false;
        }
    }
}