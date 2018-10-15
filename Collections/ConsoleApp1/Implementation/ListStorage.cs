using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class ListStorage<T> : IStorage<T> where T : IStorageObject
    {
        //TODO: Implement
        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T item)
        {
            throw new NotImplementedException();
        }

        public void InsertMany(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public bool Update(T element)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Filter(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}