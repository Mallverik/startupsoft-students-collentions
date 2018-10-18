using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DictionaryStorageLINQ<T> : IStorage<T> where T : IStorageObject
    {
        Dictionary<string, T> StorageDictionary = new Dictionary<string, T>();
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
            var res = StorageDictionary.Keys.Any(item => item == id);
            if (!res)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<T> Filter(Predicate<T> predicate)
        {
            return StorageDictionary.Values.Where(item => predicate(item));
        }

        public T GetById(string id)
        {

            if (!StorageDictionary.ContainsKey(id))
            {
                throw new ArgumentException();
            }
            return StorageDictionary[id];
        }

        public void Insert(T item)
        {
            var res = StorageDictionary.Keys.Any(i => i == item.Id);
            if (res)
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
            if (!StorageDictionary.ContainsKey(element.Id))
            {
                return false;
            }
            StorageDictionary[element.Id] = element;
            return true;
        }
    }
}
