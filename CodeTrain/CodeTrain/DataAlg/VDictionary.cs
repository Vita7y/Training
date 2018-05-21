using System.Collections;
using System.Collections.Generic;

namespace CodeTrain.DataAlg
{
    public struct KeyValue<TKey, TVal>
    {
        public KeyValue(TKey key, TVal value)
        {
            Key = key;
            Value = value;
        }
        public TKey Key { get; }
        public TVal Value { get; }
    }

    public class VDictionary<TKey, TVal>: IEnumerator<KeyValue<TKey, TVal>>
    {
        private KeyValue<TKey, TVal>[] _arr;
        public VDictionary()
        {
            _arr = new KeyValue<TKey, TVal>[32];
        }

        public void Add(TKey key, TVal value)
        {

        }

        public void Delete(TKey key)
        {

        }

        public int Count => 0;

        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public KeyValue<TKey, TVal> Current { get; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}