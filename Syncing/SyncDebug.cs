using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();

            Parallel.ForEach(items, i =>
            {
                var r = i;  // No need for async here, Parallel.ForEach already runs in parallel.
                bag.Add(r);
            });

            return bag.ToList();
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();
            var concurrentDictionary = new ConcurrentDictionary<int, string>();

            // Ensure each item is initialized exactly once using Lazy<T>
            var lazyValues = new ConcurrentDictionary<int, Lazy<string>>();

            Parallel.ForEach(itemsToInitialize, item =>
            {
                lazyValues.GetOrAdd(item, key => new Lazy<string>(() => getItem(key), LazyThreadSafetyMode.ExecutionAndPublication));
            });

            foreach (var kv in lazyValues)
            {
                concurrentDictionary[kv.Key] = kv.Value.Value;
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}