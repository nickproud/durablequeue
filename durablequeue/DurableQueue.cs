using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace durablequeue
{
    public class DurableQueue<T>
    {
        private ConcurrentQueue<T> _thisQueue;
        private IStore _storage;
        
        public DurableQueue(T queueType, IStore storageLocation)
        {
            _thisQueue = new ConcurrentQueue<T>();
            _storage = storageLocation;
        }

        public void Enqueue(T item)
        {
            var itemJson = JsonConvert.SerializeObject(item);
            _storage.Insert(itemJson);
            _thisQueue.Enqueue(item);
        }
    }
}
