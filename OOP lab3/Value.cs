using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab3
{
    public class Value<TKey> where TKey : IComparable<TKey>
    {
        public TKey Key { get; private set; }

        public Value(TKey key)
        {
            Key = key;
        }

        public TKey GetMatchingKey()
        {
            return Key;
        }
    }

}
