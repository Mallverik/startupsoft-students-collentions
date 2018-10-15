using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test(new DictionaryStorage<TestItem>());
            Test(new ListStorage<TestItem>());
        }

        private static void Test(IStorage<TestItem> storage)
        {
            Console.WriteLine($"Running test for {storage.GetType()}");
            storage.Clear();
            Debug.Assert(storage.Count() == 0, "should be empty after clear()");
            var items = new List<TestItem>
            {
                new TestItem
                {
                    Text = "Hello, its-a me, Mario!"
                },
                new TestItem
                {
                    Text = "Test"
                }
            };
            storage.InsertMany(items);
            Debug.Assert(storage.Count() == 2, "should have two items");
            var specialItem = new TestItem
            {
                Text = "Testor"
            };
            storage.Insert(specialItem);
            try
            {
                storage.Insert(specialItem);
                Debug.Assert(false, "Should have failed with ArgumentException");
            }
            catch (ArgumentException e)
            {

            }
            catch (Exception e)
            {
                Debug.Assert(false, "Should have failed with ArgumentException");
            }

            Debug.Assert(storage.Filter(i => i.Text.StartsWith("Test")).Count() == 2, "Should have found two objects");
            Debug.Assert(!storage.Exists(id: string.Empty), "Should have found no objects");
            var notInStorage = new TestItem();
            Debug.Assert(!storage.Update(notInStorage), "Should have not updated item that is not in storage");
            specialItem.Text = "Hola";
            Debug.Assert(storage.Update(specialItem), "Should have updated item that is in storage");
            Debug.Assert(storage.GetById(specialItem.Id).Text == specialItem.Text, "Should have the same value");
        }
    }
}
