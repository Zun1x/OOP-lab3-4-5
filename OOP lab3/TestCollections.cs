using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab3
{
    public class TestCollections<TKey, TValue> where TKey : IComparable<TKey>
    {
        private List<TKey> keysList;
        private List<string> stringList;
        private Dictionary<TKey, TValue> keysDictionary;
        private Dictionary<string, TValue> stringDictionary;

        public TestCollections(int numOfElements)
        {
            keysList = new List<TKey>();
            keysDictionary = new Dictionary<TKey, TValue>();
            stringList = new List<string>();
            stringDictionary = new Dictionary<string, TValue>();

            Random rand = new Random();

            for (int i = 0; i < numOfElements; i++)
            {
                TKey key = GenerateKey();
                keysList.Add(key);
                keysDictionary.Add(key, GenerateValue(key));

                stringList.Add(key.ToString());
                stringDictionary.Add(key.ToString(), GenerateValue(key));
            }
        }

        private TKey GenerateKey()
        {
            if (typeof(TKey).Equals(typeof(Guid)))
            {
                return (TKey)(object)Guid.NewGuid();
            }
            throw new NotSupportedException("Unsupported TKey type. TKey must be Guid.");
        }


        private TValue GenerateValue(TKey key)
        {
            if (typeof(TValue) == typeof(Value<TKey>))
            {
                return (TValue)(object)new Value<TKey>(key);
            }
            throw new NotSupportedException("Unsupported TValue type. TValue must be Value<TKey>.");
        }

        public TimeSpan SearchListElementTime(TKey element)
        {
            var stopwatch = Stopwatch.StartNew();
            bool contains = keysList.Contains(element);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        // Додайте інші методи пошуку тут

    }
}
