using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface IStorage<T> where T : IStorageObject
    {
        /// <summary>
        /// Returns element from storage with given id. If element is not found, <see cref="ArgumentException"/> is thrown.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(string id);

        /// <summary>
        /// Stores given item in storage. If element with given id exists, <see cref="ArgumentException"/> is thrown.
        /// </summary>
        /// <param name="item"></param>
        void Insert(T item);

        /// <summary>
        /// Stores given items in storage. If element with given id exists, <see cref="ArgumentException"/> is thrown.
        /// </summary>
        /// <param name="item"></param>
        void InsertMany(IEnumerable<T> items);

        /// <summary>
        /// Updates element if element key of given element exist in storage, otherwise does nothing
        /// Returns true if element has been modified, false if it was not found in cache
        /// </summary>
        /// <param name="item"></param>
        bool Update(T element);

        /// <summary>
        /// Whether given key is present in storage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(string id);

        /// <summary>
        /// Returns all items from storage that satisfy the predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Filter(Predicate<T> predicate);

        /// <summary>
        /// Clears all items in the storage
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns amount of items in storage
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}