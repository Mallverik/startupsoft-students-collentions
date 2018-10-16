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
            foreach (var items in StorageObjectList)
            {
                if (items.Id == item.Id)
                {
                    throw new ArgumentException();
                }

            }
            StorageObjectList.Add(item);
        }

        public void InsertMany(IEnumerable<T> items)
        {
            foreach (var count in items)
            {
                Insert(count);
            }
            
        }

        public bool Update(T element)
        {
            foreach (var items in StorageObjectList)
            {
                if (items.Id == element.Id)
                {
                    StorageObjectList[StorageObjectList.IndexOf(element)] = element;
                    return true;
                }
              
            }
            return false;
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