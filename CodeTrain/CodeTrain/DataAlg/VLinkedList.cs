using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace CodeTrain.DataAlg
{
    public class VLinkedList<T>:IEnumerable<T>
    {
        private class Node
        {
            public Node Next;
            public Node Prev;
            public T Value;
        }

        private Node _first;
        private Node _last;
        private int _count;

        public VLinkedList()
        {
            _first = _last = null;
            _count = 0;
        }

        public void Add(T item)
        {
            _count++;
            var node = new Node()
            {
                Value = item,
                Prev = _last
            };

            if (_first == null)
                _first = node;
            if (_last != null)
                _last.Next = node;
            _last = node;
        }

        public void Delete(T item)
        {
            var cur = _first;
            do
            {
                if (cur.Value.Equals(item))
                {
                    _count--;

                    if (cur == _first)
                        _first = cur?.Next;
                    if (cur == _last)
                        _last = cur?.Prev;

                    if (cur.Next != null)
                        cur.Next.Prev = cur.Prev;
                    if (cur.Prev != null)
                        cur.Prev.Next = cur.Next;
                    return;
                }

                cur = cur.Next;
            } while (cur!=null && !cur.Equals(_last));

            if (cur!=null
                &&cur.Value.Equals(item) 
                && cur == _last)
            {
                _count--;
                _last = cur.Prev;
                _last.Next = null;
            }

        }

        public int Count()
        {
            return _count;
        }

        public T First()
        {
            if (_first == null)
                return default(T);
            return _first.Value;
        }

        public T Last()
        {
            if (_last == null)
                return default(T);
            return _last.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}