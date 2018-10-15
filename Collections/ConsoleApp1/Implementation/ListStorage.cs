using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    public class ListStorage<T> : IStorage<T> where T : IStorageObject
    {
        List<T> StorageObjectList = new List<T>();
        
        public T GetById(string id)
        {
            foreach (var items in StorageObjectList)
            {
                if (items.Id == id)
                {
                    return items;
                }

            }
             throw new ArgumentException();
        }

        public void Insert(T item)
        {
            if (StorageObjectList.IndexOf(item) != -1)
            {
                throw new ArgumentException();
            }
            StorageObjectList.Add(item);
        }

        public void InsertMany(IEnumerable<T> items)
        {
            foreach (var count in items)
            {
                if (StorageObjectList.IndexOf(count) != -1)
                {
                    throw new ArgumentException();
                }
                StorageObjectList.Add(count);
            }
            
        }

        public bool Update(T element)
        {
            if (StorageObjectList.IndexOf(element) == -1)
            {
                return false;
            }
            else
            {
                StorageObjectList[StorageObjectList.IndexOf(element)] = element;
                return true;
            }
        }

        public bool Exists(string id)
        {
            foreach (var items in StorageObjectList)
            {
                if (items.Id == id)
                {
                    return true;
                }

            }
            return false;
        }

        public IEnumerable<T> Filter(Predicate<T> predicate)
        {
            foreach (var items in StorageObjectList)
            {
                if (predicate(items))
                {
                    yield return items;
                }
            }
        }

        public void Clear()
        {
            StorageObjectList.Clear();
        }

        public int Count()
        {
            return StorageObjectList.Count;
        }
    }
}