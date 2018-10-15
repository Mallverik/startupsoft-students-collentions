using System;

namespace ConsoleApp1.Model
{
    public class TestItem : IStorageObject
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
    }
}