using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ListStorageLINQ<T> : IStorage<T> where T : IStorageObject
    {
        List<T> StorageObjectList = new List<T>();

        public void Clear()
        {
            StorageObjectList.Clear();
        }

        public int Count()
        {
           return StorageObjectList.Count;
        }

        public bool Exists(string id)
        {

            var res = StorageObjectList.Any(item => item.Id == id);
            if (!res)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<T> Filter(Predicate<T> predicate)
        {
            return StorageObjectList.Where(items => predicate(items));
            
        }

        public T GetById(string id)
        {
            var res = StorageObjectList.FirstOrDefault(items => items.Id == id);
            if (res == null)
            {
                throw new ArgumentException();
            }
            return res;
        }

        public void Insert(T item)
        {
            var res = StorageObjectList.Any(items => items.Id == item.Id);
            if (res)
            {
                throw new ArgumentException();
            }
            StorageObjectList.Add(item);
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
            var res = StorageObjectList.IndexOf(StorageObjectList.FirstOrDefault(item => item.Id == element.Id));
            if (res == -1)
            {
                return false;
            }
            StorageObjectList[res] = element;
            return true;
        }
    }
}
